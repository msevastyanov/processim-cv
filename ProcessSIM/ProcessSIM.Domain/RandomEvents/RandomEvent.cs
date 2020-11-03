namespace ProcessSIM.Domain.RandomEvents
{
    public class RandomEvent
    {
        public string EventName { get; set; }
        public string EventAlias { get; set; }
        public int DurationFrom { get; set; }
        public int DurationTo { get; set; }
        public int Probability { get; set; }
    }
}