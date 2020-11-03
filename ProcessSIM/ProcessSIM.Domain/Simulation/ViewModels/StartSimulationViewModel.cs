using System.Collections.Generic;

namespace ProcessSIM.Domain.Simulation.ViewModels
{
    public class StartSimulationViewModel
    {
        public List<ProcedureViewModel> Procedures { get; set; }
        public List<ResourceViewModel> Resources { get; set; }
        public List<ProcProcLink> ProcLinks { get; set; }
        public List<ProcResLink> ProcResLinks { get; set; }
        public string StartProcKey { get; set; }
        public int MaxTime { get; set; }
        public int Step { get; set; }
        public double Complexity { get; set; }
        public string SimulationName { get; set; }
    }
}