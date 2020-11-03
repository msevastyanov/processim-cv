using System.Collections.Generic;

namespace ProcessSIM.Domain.Procedures
{
    public class Procedure : IProcedure
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string ProgressFunction { get; set; }
        public List<ProcedureParameter> Parameters { get; set; }
        public string[] PossibleEvents { get; set; }
        public string ResourcesList { get; set; }
    }
}