using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProcessSIM.Application.Extensions;
using ProcessSIM.ServiceLayer.Services;
using ProcessSIM.ServiceLayer.ViewModels.ResourceParameterValues;

namespace ProcessSIM.Application.Controllers
{
    [Route("api/parameterValue")]
    [Authorize]
    [ApiController]
    public class ResourceParameterValueController : Controller
    {
        private readonly IResourceParameterValueService _resourceParameterValueService;

        public ResourceParameterValueController(IResourceParameterValueService resourceParameterValueService)
        {
            _resourceParameterValueService = resourceParameterValueService;
        }

        [HttpGet("{resId}")]
        public async Task<IActionResult> GetResourceParameters(int resId)
        {
            var resParameters = await _resourceParameterValueService.GetResourceParametersByResource(resId);
            return Json(new {resParameters});
        }

        [HttpPost("{id}/update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateResourceType(int id,
            [FromBody] UpdateResourceParameterValueViewModel model)
        {
            var result = await _resourceParameterValueService.UpdateResourceParameterValue(id, model);

            return result.ToJsonResult();
        }
    }
}