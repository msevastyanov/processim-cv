using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessSIM.Domain.Procedures;
using ProcessSIM.ServiceLayer.ViewModels.Procedures;

namespace ProcessSIM.ServiceLayer.Services
{
    public class ProcedureService : IProcedureService
    {
        public List<ProcedureViewModel> GetAllProcedures()
        {
            var procedures = ProceduresBuilder.GetProcedures();
            return procedures.Select(x => new ProcedureViewModel(x)).ToList();
        }
    }
}