using ProcessSIM.Domain.RandomEvents;

namespace ProcessSIM.Domain.Simulation
{
    public class SimRandomEvent
    {
        public RandomEvent Event { get; set; }
        public bool IsHappened { get; set; }
        public RandomEventStatus Status { get; set; }
        public int Duration { get; set; }
        public int TimeStart { get; set; }
        public int TimeEnd { get; set; }
    }
    
    public enum RandomEventStatus
    {
        NotStarted,
        Started,
        Finished
    }
}