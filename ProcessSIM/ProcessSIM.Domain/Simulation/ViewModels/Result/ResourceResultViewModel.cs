using System.Collections.Generic;

namespace ProcessSIM.Domain.Simulation.ViewModels.Result
{
    public class ResourceResultViewModel
    {
        public string ResourceName { get; set; }
        public decimal Cost { get; set; }
        public List<ActiveTimeItem> ActiveTime { get; set; }
        public int UseTime { get; set; }
        public int Downtime { get; set; }
    }

    public class ActiveTimeItem
    {
        public int From { get; set; }
        public int To { get; set; }
    }
}