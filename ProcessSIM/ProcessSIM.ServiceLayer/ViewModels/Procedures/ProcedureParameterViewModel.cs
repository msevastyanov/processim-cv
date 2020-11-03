using ProcessSIM.Domain.Procedures;

namespace ProcessSIM.ServiceLayer.ViewModels.Procedures
{
    public class ProcedureParameterViewModel
    {
        public string Name { get; set; }
        public string Alias { get; set; }

        public ProcedureParameterViewModel(ProcedureParameter model)
        {
            Name = model.Name;
            Alias = model.Alias;
        }
    }
}