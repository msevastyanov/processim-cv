using System.Threading.Tasks;
using ProcessSIM.Domain.Simulation.ViewModels;
using ProcessSIM.Domain.Simulation.ViewModels.Result;
using ProcessSIM.ServiceLayer.Models;

namespace ProcessSIM.ServiceLayer.Services
{
    public interface ISimulationService
    {
        Task<RequestResult<SimulationResultViewModel>> StartSimulation(StartSimulationViewModel model, string userId);
    }
}