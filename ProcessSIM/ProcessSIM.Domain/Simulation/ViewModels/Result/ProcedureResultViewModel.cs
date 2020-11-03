using System.Collections.Generic;

namespace ProcessSIM.Domain.Simulation.ViewModels.Result
{
    public class ProcedureResultViewModel
    {
        public string ProcedureAlias { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public int Duration { get; set; }
        public int WaitingTime { get; set; }
        public List<RandomEventResultViewModel> RandomEvents { get; set; }
    }
}