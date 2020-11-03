using System;
using System.Collections.Generic;
using System.Linq;
using ProcessSIM.Domain.Entities.History;

namespace ProcessSIM.Domain.Simulation.ViewModels.Result
{
    public class SimulationResultViewModel
    {
        public int Duration { get; set; }
        public int WaitingTime { get; set; }
        public decimal TotalCost { get; set; }
        public string SimulationName { get; set; }
        public string AuthorName { get; set; }
        public double Complexity { get; set; }
        public int Step { get; set; }
        public int RandomEventsDuration { get; set; }
        public DateTime DateTime { get; set; }
        public List<ProcedureResultViewModel> ProcedureResults { get; set; }
        public List<ResourceResultViewModel> ResourceResults { get; set; }
        public bool IsSuccess { get; set; }
        public string Error { get; set; }

        public SimulationResultViewModel()
        {
            
        }

        public SimulationResultViewModel(SimulationHistory history)
        {
            Duration = history.Duration;
            WaitingTime = history.WaitingTime;
            TotalCost = history.TotalCost;
            SimulationName = history.SimulationName.Name;
            AuthorName = history.AuthorName;
            Complexity = history.Complexity;
            Step = history.Step;
            DateTime = history.DateTime;
            IsSuccess = true;
            ProcedureResults = history.Procedures.Select(x => new ProcedureResultViewModel
            {
                ProcedureAlias = x.ProcedureAlias,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Duration = x.EndTime - x.StartTime,
                WaitingTime = x.WaitingTime,
                RandomEvents = x.RandomEvents.Select(e => new RandomEventResultViewModel
                {
                    EventName = e.EventAlias,
                    TimeStart = e.StartTime,
                    TimeEnd = e.EndTime,
                    Duration = e.EndTime - e.StartTime,
                }).ToList()
            }).ToList();
            ResourceResults = history.Resources.Select(x => new ResourceResultViewModel
            {
                ResourceName = x.ResourceName,
                Cost = x.Cost,
                Downtime = x.Downtime,
                UseTime = x.UseTime,
                ActiveTime = x.UseHistory.Select(t => new ActiveTimeItem
                {
                    From = t.StartTime,
                    To = t.EndTime
                }).ToList(),

            }).ToList();
            RandomEventsDuration = ProcedureResults.SelectMany(x => x.RandomEvents).Sum(x => x.Duration);
        }
    }
}