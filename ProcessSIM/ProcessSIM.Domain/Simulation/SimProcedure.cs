using System;
using System.Collections.Generic;
using System.Linq;
using ProcessSIM.Domain.Procedures;
using org.mariuszgromada.math.mxparser;

namespace ProcessSIM.Domain.Simulation
{
    public class SimProcedure : ISimProcedure
    {
        public string ProcedureKey { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public int WaitingTime { get; set; }
        public Procedure Procedure { get; set; }
        public List<ProcedureParameterValue> ParameterValues { get; set; }
        public List<SimProcedure> PrevProcedures { get; set; }
        public List<SimProcedure> NextProcedures { get; set; }
        public List<SimResource> SimResources { get; set; }
        public List<SimRandomEvent> SimRandomEvents { get; set; }
        public ProcedureStatus Status { get; set; }
        public Dictionary<string, string> AllParams { get; set; }
        private Random rand { get; set; }
        private bool IsAllRandomEventsCompleted { get; set; }

        public SimProcedure()
        {
            rand = new Random();
            IsAllRandomEventsCompleted = false;
            WaitingTime = 0;
        }

        double GetProgressFunctionValue(int x)
        {
            var expression = Procedure.ProgressFunction;

            foreach (var param in AllParams)
            {
                expression = expression.Replace(param.Key, param.Value);
            }

            expression = expression.Replace("[x]", x.ToString());
            
            // if (expression.Contains("design_object_complexity"))
            if (AllParams.ContainsKey("[design_object_complexity]") && AllParams["[design_object_complexity]"] == null)
                throw new SimulationException($"Укажите сложность ОП у процедуры {Procedure.Alias}");

            if (expression.Contains("["))
                throw new SimulationException($"Не хватает ресурсов у процедуры {Procedure.Alias}");
            
            var result = new Expression(expression).calculate();
            return result;
        }

        public void UpdateState(int currentTime, int step)
        {
            switch (Status)
            {
                case ProcedureStatus.NotStarted:
                {
                    if (SimResources.All(x => x.Status == ResourceStatus.Free))
                    {
                        Status = ProcedureStatus.Started;
                        StartTime = currentTime;
                        SetResourcesStatus(ResourceStatus.Busy, currentTime);
                        InitRandomEvents();
                    }
                    else
                    {
                        WaitingTime += step;
                    }

                    break;
                }
                case ProcedureStatus.Started:
                {
                    var completionLevel = GetProgressFunctionValue(currentTime - StartTime);
                    if (Double.IsNaN(completionLevel))
                        throw new SimulationException($"Не хватает значений параметров процедуры {Procedure.Alias}");
                    if (completionLevel >= 1)
                    {
                        if (!IsAllRandomEventsCompleted)
                            IsAllRandomEventsCompleted = CheckRandomEventsStatus();

                        if (!IsAllRandomEventsCompleted)
                        {
                            UpdateEventsState(currentTime);
                            IsAllRandomEventsCompleted = CheckRandomEventsStatus();
                        }

                        if (IsAllRandomEventsCompleted)
                        {
                            Status = ProcedureStatus.Finished;
                            EndTime = currentTime;
                            SetResourcesStatus(ResourceStatus.Free, currentTime);
                            foreach (var procedure in NextProcedures)
                            {
                                procedure.UpdateState(currentTime, step);
                            }
                        }
                    }

                    break;
                }
                case ProcedureStatus.Finished:
                {
                    foreach (var procedure in NextProcedures)
                    {
                        procedure.UpdateState(currentTime, step);
                    }

                    break;
                }
            }
        }

        void SetResourcesStatus(ResourceStatus status, int currentTime)
        {
            foreach (var resource in SimResources)
            {
                resource.Status = status;
                switch (status)
                {
                    case ResourceStatus.Busy:
                        resource.ActiveTime.Add((currentTime, 0));
                        break;
                    case ResourceStatus.Free:
                    {
                        var lastActiveTime = resource.ActiveTime.Last();
                        resource.ActiveTime.Remove(lastActiveTime);
                        resource.ActiveTime.Add((lastActiveTime.Item1, currentTime));
                        break;
                    }
                }
            }
        }

        void InitRandomEvents()
        {
            foreach (var randomEvent in SimRandomEvents)
            {
                var isHappened = rand.Next(100) + 1 <= randomEvent.Event.Probability;
                randomEvent.IsHappened = isHappened;

                if (!isHappened)
                    continue;

                randomEvent.Status = RandomEventStatus.NotStarted;
                randomEvent.Duration = rand.Next(randomEvent.Event.DurationFrom, randomEvent.Event.DurationTo + 1);
            }
        }

        bool CheckRandomEventsStatus()
        {
            return SimRandomEvents.All(x => x.Status == RandomEventStatus.Finished || !x.IsHappened);
        }

        void UpdateEventsState(int currentTime)
        {
            foreach (var randomEvent in SimRandomEvents.Where(x => x.IsHappened))
            {
                switch (randomEvent.Status)
                {
                    case RandomEventStatus.Finished:
                        continue;
                    case RandomEventStatus.NotStarted:
                        randomEvent.TimeStart = currentTime;
                        randomEvent.TimeEnd = currentTime + randomEvent.Duration;
                        randomEvent.Status = RandomEventStatus.Started;
                        break;
                    case RandomEventStatus.Started:
                    {
                        if (currentTime >= randomEvent.TimeEnd)
                        {
                            randomEvent.Status = RandomEventStatus.Finished;
                        }

                        break;
                    }
                }

                break;
            }
        }
    }

    public enum ProcedureStatus
    {
        NotStarted,
        Started,
        Finished
    }
}