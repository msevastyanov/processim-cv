using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProcessSIM.Application.Extensions;
using ProcessSIM.ServiceLayer.Services;
using ProcessSIM.ServiceLayer.ViewModels.Resources;

namespace ProcessSIM.Application.Controllers
{
    [Route("api/resource")]
    [Authorize]
    [ApiController]
    public class ResourceController : Controller
    {
        private readonly IResourceService _resourceService;

        public ResourceController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllResources()
        {
            var resources = await _resourceService.GetAllResources();
            return Json(new {resources});
        }

        [HttpGet("{typeId}")]
        public async Task<IActionResult> GetResources(int typeId)
        {
            var resources = await _resourceService.GetResourcesByType(typeId);
            return Json(new {resources});
        }

        [HttpPost("{typeId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateResource(int typeId, [FromBody] CreateResourceViewModel model)
        {
            var result = await _resourceService.AddResource(typeId, model);

            return result.ToJsonResult();
        }

        [HttpPost("{id}/update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateResource(int id, [FromBody] UpdateResourceViewModel model)
        {
            var result = await _resourceService.UpdateResource(id, model);

            return result.ToJsonResult();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteResource(int id)
        {
            var result = await _resourceService.DeleteResource(id);

            return result.ToJsonResult();
        }
    }
}