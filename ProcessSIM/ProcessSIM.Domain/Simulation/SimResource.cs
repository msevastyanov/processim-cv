using System.Collections.Generic;
using ProcessSIM.Domain.Entities;

namespace ProcessSIM.Domain.Simulation
{
    public class SimResource
    {
        public Resource Resource { get; set; }
        public List<SimProcedure> SimProcedures { get; set; }
        public ResourceStatus Status { get; set; }
        public string ResourceKey { get; set; }
        public List<(int, int)> ActiveTime { get; set; }
    }
    
    public enum ResourceStatus
    {
        Free, Busy
    }
}