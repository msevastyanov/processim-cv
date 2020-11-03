using System;
using System.Collections.Generic;

namespace ProcessSIM.Domain.Entities.History
{
    public class SimulationHistory
    {
        public int SimulationHistoryId { get; set; }
        public int Duration { get; set; }
        public int WaitingTime { get; set; }
        public decimal TotalCost { get; set; }
        public double Complexity { get; set; }
        public int Step { get; set; }
        public string Username { get; set; }
        public string AuthorName { get; set; }
        public DateTime DateTime { get; set; }
        public List<ResourceHistory> Resources { get; set; }
        public List<ProcedureHistory> Procedures { get; set; }
        public SimulationName SimulationName { get; set; }
    }
}