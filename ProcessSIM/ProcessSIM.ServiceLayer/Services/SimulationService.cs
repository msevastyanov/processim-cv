using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProcessSIM.Domain.Auth;
using ProcessSIM.Domain.Entities.History;
using ProcessSIM.Domain.Simulation;
using ProcessSIM.Domain.Simulation.ViewModels;
using ProcessSIM.Domain.Simulation.ViewModels.Result;
using ProcessSIM.Infrastructure.Repositories;
using ProcessSIM.ServiceLayer.Models;
using ProcessSIM.Simulation;

namespace ProcessSIM.ServiceLayer.Services
{
    public class SimulationService : ISimulationService
    {
        private IResourceRepository _resourceRepository;
        private ISimulationHistoryRepository _simulationHistoryRepository;
        private ISimulationNameRepository _simulationNameRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public SimulationService(IResourceRepository resourceRepository,
            ISimulationHistoryRepository simulationHistoryRepository,
            ISimulationNameRepository simulationNameRepository,
            UserManager<ApplicationUser> userManager)
        {
            _resourceRepository = resourceRepository;
            _simulationHistoryRepository = simulationHistoryRepository;
            _simulationNameRepository = simulationNameRepository;
            _userManager = userManager;
        }

        public async Task<RequestResult<SimulationResultViewModel>> StartSimulation(StartSimulationViewModel model,
            string userId)
        {
            var resources = await _resourceRepository.GetAllResources();

            var simCore = new SimulationCore(resources);
            
            var currentUser = await _userManager.FindByIdAsync(userId);

            SimulationHistory history;

            try
            {
                history = simCore.SimulationStart(model);
            }
            catch (SimulationException ex)
            {
                return RequestResult<SimulationResultViewModel>.Success(new SimulationResultViewModel
                {
                    IsSuccess = false,
                    Error = ex.Message
                });
            }

            history.Username = currentUser.UserName;
            history.AuthorName = $"{currentUser.LastName} {currentUser.FirstName}";

            var simName =
                await _simulationNameRepository.FindSimulationNameByUsername(model.SimulationName,
                    currentUser.UserName);

            if (simName == null)
            {
                var newSimName = new SimulationName
                {
                    Name = model.SimulationName,
                    Username = currentUser.UserName
                };

                await _simulationNameRepository.AddSimulationName(newSimName);
                
                history.SimulationName = newSimName;
            }
            else
            {
                history.SimulationName = simName;
            }
            

            await _simulationHistoryRepository.AddSimulationHistory(history);

            return RequestResult<SimulationResultViewModel>.Success(new SimulationResultViewModel(history));
        }
    }
}