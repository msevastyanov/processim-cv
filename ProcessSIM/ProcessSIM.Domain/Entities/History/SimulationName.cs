using System.Collections.Generic;

namespace ProcessSIM.Domain.Entities.History
{
    public class SimulationName
    {
        public int SimulationNameId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public List<SimulationHistory> HistoryList { get; set; }
    }
}