using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProcessSIM.Application.Extensions;
using ProcessSIM.ServiceLayer.Services;
using ProcessSIM.ServiceLayer.ViewModels.ResourceParameters;

namespace ProcessSIM.Application.Controllers
{
    [Route("api/parameter")]
    [Authorize]
    [ApiController]
    public class ResourceParameterController : Controller
    {
        private readonly IResourceParameterService _resourceParameterService;

        public ResourceParameterController(IResourceParameterService resourceParameterService)
        {
            _resourceParameterService = resourceParameterService;
        }

        [HttpGet("{resTypeId}")]
        public async Task<IActionResult> GetResourceParameters(int resTypeId)
        {
            var resParameters = await _resourceParameterService.GetResourceParametersByResourceType(resTypeId);
            return Json(new {resParameters});
        }

        [HttpPost("{resTypeId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateResourceParameter(int resTypeId,
            [FromBody] CreateResourceParameterViewModel model)
        {
            var result = await _resourceParameterService.AddResourceParameter(resTypeId, model);

            return result.ToJsonResult();
        }

        [HttpPost("{resTypeId}/{paramId}/update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateResourceParameter(int resTypeId, int paramId,
            [FromBody] UpdateResourceParameterViewModel model)
        {
            var result = await _resourceParameterService.UpdateResourceParameter(resTypeId, paramId, model);

            return result.ToJsonResult();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteResourceParameter(int id)
        {
            var result = await _resourceParameterService.DeleteResourceParameter(id);

            return result.ToJsonResult();
        }
    }
}