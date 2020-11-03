using System.Collections.Generic;
using System.Linq;
using ProcessSIM.Domain.Entities;
using ProcessSIM.Domain.Procedures;
using ProcessSIM.ServiceLayer.ViewModels.ResourceTypes;

namespace ProcessSIM.ServiceLayer.ViewModels.Procedures
{
    public class ProcedureViewModel
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string ResourcesList { get; set; }

        public List<ProcedureParameterViewModel> Parameters { get; set; }

        public ProcedureViewModel(Procedure model)
        {
            Name = model.Name;
            Alias = model.Alias;
            ResourcesList = model.ResourcesList;
            Parameters = model.Parameters.Select(x => new ProcedureParameterViewModel(x)).ToList();
        }
    }
}