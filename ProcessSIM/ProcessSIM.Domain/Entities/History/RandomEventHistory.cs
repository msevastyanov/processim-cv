namespace ProcessSIM.Domain.Entities.History
{
    public class RandomEventHistory
    {
        public int RandomEventHistoryId { get; set; }
        public string EventName { get; set; }
        public string EventAlias { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
    }
}