using System;
using System.Collections.Generic;
using System.Linq;
using ProcessSIM.Domain.Entities;
using ProcessSIM.Domain.Entities.History;
using ProcessSIM.Domain.Procedures;
using ProcessSIM.Domain.RandomEvents;
using ProcessSIM.Domain.Simulation;
using ProcessSIM.Domain.Simulation.ViewModels;
using ProcessSIM.Domain.Simulation.ViewModels.Result;

namespace ProcessSIM.Simulation
{
    public class SimulationCore : ISimulationCore
    {
        private List<Resource> Resources { get; set; }
        private List<RandomEvent> RandomEvents { get; set; }
        private SimProcedure StartProcedure { get; set; }
        private List<SimProcedure> SimProcedures { get; set; }
        private List<SimResource> SimResources { get; set; }
        private int CurrentTime { get; set; }
        private int Step { get; set; }
        private double Complexity { get; set; }

        public SimulationCore(List<Resource> resources)
        {
            Resources = resources;
            RandomEvents = RandomEventsBuilder.GetRandomEvents().ToList();
            CurrentTime = 0;
            Step = 2;
        }

        public SimulationHistory SimulationStart(StartSimulationViewModel model)
        {
            Step = model.Step;
            Complexity = model.Complexity;
            StartProcedure = GenerateSimGraph(model);

            CheckConntection();
            Simulate();

            return GetSimHistory();
        }

        SimulationHistory GetSimHistory()
        {
            var history = new SimulationHistory
            {
                Duration = CurrentTime,
                WaitingTime = SimProcedures.Sum(x => x.WaitingTime),
                TotalCost = SimResources.Sum(x => x.Resource.Price),
                Complexity = Complexity,
                Step = Step,
                DateTime = DateTime.Now,
                Resources = SimResources.Select(x => new ResourceHistory
                {
                    ResourceName = x.Resource.ResourceName,
                    ResourceId = x.Resource.ResourceId,
                    Cost = x.Resource.Price,
                    UseTime = x.ActiveTime.Sum(t => t.Item2 - t.Item1),
                    Downtime = CurrentTime - x.ActiveTime.Sum(t => t.Item2 - t.Item1),
                    UseHistory = x.ActiveTime.Select(t => new ResourceUseHistory
                    {
                        StartTime = t.Item1,
                        EndTime = t.Item2
                    }).ToList(),
                }).ToList(),
                Procedures = SimProcedures.Select(x => new ProcedureHistory
                {
                    ProcedureName = x.Procedure.Name,
                    ProcedureAlias = x.Procedure.Alias,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    WaitingTime = x.WaitingTime,
                    RandomEvents = x.SimRandomEvents.Where(e => e.IsHappened).Select(e => new RandomEventHistory
                    {
                        EventName = e.Event.EventName,
                        EventAlias = e.Event.EventAlias,
                        StartTime = e.TimeStart,
                        EndTime = e.TimeEnd
                    }).ToList()
                }).ToList()
            };

            return history;
        }

        void Simulate()
        {
            var isFinished = false;

            while (!isFinished)
            {
                StartProcedure.UpdateState(CurrentTime, Step);

                isFinished = SimProcedures.All(x => x.Status == ProcedureStatus.Finished);

                if (!isFinished)
                    CurrentTime += Step;
            }
        }

        SimProcedure GenerateSimGraph(StartSimulationViewModel model)
        {
            SimProcedures = GetSimProcedures(model.Procedures);
            SimResources = GetSimResources(model.Resources);

            CreateProceduresLinks(model.ProcLinks);
            CreateResourcesLinks(model.ProcResLinks);
            UpdateProceduresResParams();

            var startProcedure = SimProcedures.SingleOrDefault(x => x.ProcedureKey == model.StartProcKey);

            return startProcedure;
        }

        List<SimProcedure> GetSimProcedures(List<ProcedureViewModel> modelProcedures)
        {
            var simProcedures = new List<SimProcedure>();
            var procedures = ProceduresBuilder.GetProcedures().ToList();

            foreach (var procedureModel in modelProcedures)
            {
                var procedure = procedures.SingleOrDefault(x => x.Name == procedureModel.ProcedureName);

                if (procedure == null)
                    continue;

                var simProcedure = new SimProcedure
                {
                    Procedure = procedure,
                    ProcedureKey = procedureModel.ProcedureKey,
                    Status = ProcedureStatus.NotStarted,
                    ParameterValues = new List<ProcedureParameterValue>(),
                    NextProcedures = new List<SimProcedure>(),
                    PrevProcedures = new List<SimProcedure>(),
                    SimResources = new List<SimResource>(),
                    SimRandomEvents = GetRandomEvents(procedure),
                    AllParams = new Dictionary<string, string>()
                };

                foreach (var param in procedureModel.ProcedureParameters)
                {
                    var trueParam = procedure.Parameters.SingleOrDefault(x => x.Name == param.ProcedureParameterName);

                    if (trueParam == null)
                        continue;

                    simProcedure.ParameterValues.Add(new ProcedureParameterValue
                    {
                        Parameter = trueParam,
                        Value = param.ProcedureParameterValue
                    });
                    simProcedure.AllParams.Add($"[{trueParam.Name}]", param.ProcedureParameterValue);
                }

                simProcedures.Add(simProcedure);
            }

            return simProcedures;
        }

        List<SimResource> GetSimResources(List<ResourceViewModel> modelResources)
        {
            return (from resourceModel in modelResources
                let resource = Resources.SingleOrDefault(x => x.ResourceId == resourceModel.ResourceId)
                where resource != null
                select new SimResource
                {
                    Resource = resource,
                    ResourceKey = resourceModel.ResourceKey,
                    Status = ResourceStatus.Free,
                    SimProcedures = new List<SimProcedure>(),
                    ActiveTime = new List<(int, int)>()
                }).ToList();
        }

        List<SimRandomEvent> GetRandomEvents(Procedure procedure)
        {
            return (from procedureEvent in procedure.PossibleEvents
                select RandomEvents.SingleOrDefault(x => x.EventName == procedureEvent)
                into trueEvent
                where trueEvent != null
                select new SimRandomEvent
                    {Event = trueEvent, IsHappened = false, Status = RandomEventStatus.NotStarted,}).ToList();
        }

        void CreateProceduresLinks(List<ProcProcLink> procLinks)
        {
            foreach (var procLink in procLinks)
            {
                var fromProc = SimProcedures.SingleOrDefault(x => x.ProcedureKey == procLink.ProcedureFromKey);
                var toProc = SimProcedures.SingleOrDefault(x => x.ProcedureKey == procLink.ProcedureToKey);

                if (fromProc == null || toProc == null)
                    continue;

                fromProc.NextProcedures.Add(toProc);
                toProc.PrevProcedures.Add(fromProc);
            }
        }

        void CreateResourcesLinks(List<ProcResLink> procResLinks)
        {
            foreach (var procResLink in procResLinks)
            {
                var proc = SimProcedures.SingleOrDefault(x => x.ProcedureKey == procResLink.ProcedureKey);
                var res = SimResources.SingleOrDefault(x => x.ResourceKey == procResLink.ResourceKey);

                if (proc == null || res == null)
                    continue;

                proc.SimResources.Add(res);
                res.SimProcedures.Add(proc);
            }
        }

        void UpdateProceduresResParams()
        {
            foreach (var procedure in SimProcedures)
            {
                if (!procedure.SimResources.Any())
                    continue;
                
                foreach (var resParam in procedure.SimResources.SelectMany(resource =>
                    resource.Resource.ResourceParameterValues))
                {
                    procedure.AllParams.Add($"[{resParam.ResourceParameter.ResourceParameterName}]",
                        resParam.ParameterValue);
                }
            }
        }

        void CheckConntection()
        {
            var wrongProc = SimProcedures.FirstOrDefault(x =>
                !x.PrevProcedures.Any() && x.ProcedureKey != StartProcedure.ProcedureKey);

            if (wrongProc != null)
                throw new SimulationException($"Не хватает соединенией у процедуры {wrongProc.Procedure.Alias}");
        }
    }
}