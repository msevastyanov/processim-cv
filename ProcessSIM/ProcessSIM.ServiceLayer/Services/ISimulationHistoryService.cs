using System.Collections.Generic;
using System.Threading.Tasks;
using ProcessSIM.Domain.Simulation.ViewModels.Result;

namespace ProcessSIM.ServiceLayer.Services
{
    public interface ISimulationHistoryService
    {
        Task<List<SimulationResultViewModel>> GetAllHistory(string userId);
    }
}