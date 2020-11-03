using System.Collections.Generic;

namespace ProcessSIM.Domain.Entities.History
{
    public class ResourceHistory
    {
        public int ResourceHistoryId { get; set; }
        public string ResourceName { get; set; }
        public int ResourceId { get; set; }
        public int UseTime { get; set; }
        public int Downtime { get; set; }
        public decimal Cost { get; set; }
        public List<ResourceUseHistory> UseHistory { get; set; }
    }
}