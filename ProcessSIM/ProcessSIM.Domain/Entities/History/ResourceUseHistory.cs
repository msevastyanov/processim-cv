namespace ProcessSIM.Domain.Entities.History
{
    public class ResourceUseHistory
    {
        public int ResourceUseHistoryId { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public ResourceHistory Resource { get; set; }
    }
}