using System.Collections.Generic;
using System.Threading.Tasks;
using ProcessSIM.ServiceLayer.ViewModels.Procedures;

namespace ProcessSIM.ServiceLayer.Services
{
    public interface IProcedureService
    {
        List<ProcedureViewModel> GetAllProcedures();
    }
}