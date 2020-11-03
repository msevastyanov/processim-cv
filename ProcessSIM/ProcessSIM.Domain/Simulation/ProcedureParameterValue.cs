using ProcessSIM.Domain.Procedures;

namespace ProcessSIM.Domain.Simulation
{
    public class ProcedureParameterValue
    {
        public string Value { get; set; }
        public ProcedureParameter Parameter { get; set; }
    }
}