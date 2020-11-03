using System.Collections.Generic;

namespace ProcessSIM.Domain.Entities.History
{
    public class ProcedureHistory
    {
        public int ProcedureHistoryId { get; set; }
        public string ProcedureName { get; set; }
        public string ProcedureAlias { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public int WaitingTime { get; set; }
        public List<RandomEventHistory> RandomEvents { get; set; }
    }
}