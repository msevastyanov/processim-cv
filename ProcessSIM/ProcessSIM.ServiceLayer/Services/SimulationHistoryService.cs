using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProcessSIM.Domain.Auth;
using ProcessSIM.Domain.Simulation.ViewModels.Result;
using ProcessSIM.Infrastructure.Repositories;
using ProcessSIM.ServiceLayer.ViewModels.ResourceCategories;

namespace ProcessSIM.ServiceLayer.Services
{
    public class SimulationHistoryService : ISimulationHistoryService
    {
        private ISimulationHistoryRepository _simulationHistoryRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public SimulationHistoryService(ISimulationHistoryRepository simulationHistoryRepository, UserManager<ApplicationUser> userManager)
        {
            _simulationHistoryRepository = simulationHistoryRepository;
            _userManager = userManager;
        }
        
        public async Task<List<SimulationResultViewModel>> GetAllHistory(string userId)
        {
            var currentUser = await _userManager.FindByIdAsync(userId);
            var isAdmin = await _userManager.IsInRoleAsync(currentUser, ApplicationUserRoles.AdminRole);
            
            var history = isAdmin ? await _simulationHistoryRepository.GetAllHistory() : await _simulationHistoryRepository.GetHistoryByUsername(currentUser.UserName);
            
            return history.OrderByDescending(x => x.DateTime).Select(x => new SimulationResultViewModel(x)).ToList();
        }
    }
}