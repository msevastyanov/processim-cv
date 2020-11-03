using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessSIM.ServiceLayer.Services;

namespace ProcessSIM.Application.Controllers
{
    [Route("api/history")]
    [Authorize]
    [ApiController]
    public class SimulationHistoryController : Controller
    {
        private readonly ISimulationHistoryService _simulationHistoryService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SimulationHistoryController(ISimulationHistoryService simulationHistoryService, IHttpContextAccessor httpContextAccessor)
        {
            _simulationHistoryService = simulationHistoryService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHistory()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            
            var historyItems = await _simulationHistoryService.GetAllHistory(userId);
            return Json(new {historyItems});
        }
    }
}