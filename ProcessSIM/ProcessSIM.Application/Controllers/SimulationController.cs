using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessSIM.Application.Extensions;
using ProcessSIM.Domain.Simulation.ViewModels;
using ProcessSIM.ServiceLayer.Services;

namespace ProcessSIM.Application.Controllers
{
    [Route("api/simulation")]
    [Authorize]
    [ApiController]
    public class SimulationController : Controller
    {
        private readonly ISimulationService _simulationService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SimulationController(ISimulationService simulationService, IHttpContextAccessor httpContextAccessor)
        {
            _simulationService = simulationService;
            _httpContextAccessor = httpContextAccessor;
        }
        
        [HttpPost]
        public async Task<IActionResult> StartSimulation([FromBody] StartSimulationViewModel model)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                
            return (await _simulationService.StartSimulation(model, userId)).ToJsonResult();
        }
    }
}