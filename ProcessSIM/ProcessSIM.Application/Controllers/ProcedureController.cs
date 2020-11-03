using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProcessSIM.ServiceLayer.Services;

namespace ProcessSIM.Application.Controllers
{
    [Route("api/procedure")]
    [Authorize]
    [ApiController]
    public class ProcedureController : Controller
    {
        private readonly IProcedureService _procedureService;

        public ProcedureController(IProcedureService procedureService)
        {
            _procedureService = procedureService;
        }

        [HttpGet]
        public IActionResult GetResourceCategories()
        {
            var procedures = _procedureService.GetAllProcedures();
            return Json(new {procedures});
        }
    }
}