using System.Collections.Generic;

namespace ProcessSIM.Domain.Simulation.ViewModels
{
    public class ProcedureViewModel
    {
        public string ProcedureKey { get; set; }
        public string ProcedureName { get; set; }
        public List<ProcedureParameterViewModel> ProcedureParameters { get; set; }
    }
}