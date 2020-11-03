using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProcessSIM.Application.Extensions;
using ProcessSIM.ServiceLayer.Services;
using ProcessSIM.ServiceLayer.ViewModels.ResourceTypes;

namespace ProcessSIM.Application.Controllers
{
    [Route("api/type")]
    [Authorize]
    [ApiController]
    public class ResourceTypeController : Controller
    {
        private readonly IResourceTypeService _resourceTypeService;

        public ResourceTypeController(IResourceTypeService resourceTypeService)
        {
            _resourceTypeService = resourceTypeService;
        }

        [HttpGet("{resTypeId}")]
        public async Task<IActionResult> GetResourceType(int resTypeId)
        {
            var result = await _resourceTypeService.GetResourceType(resTypeId);
            
            return result.ToJsonResult();
        }

        [HttpPost("{resCatId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateResourceType(int resCatId, [FromBody] CreateResourceTypeViewModel model)
        {
            var result = await _resourceTypeService.AddResourceType(resCatId, model);
            
            return result.ToJsonResult();
        }

        [HttpPost("{id}/update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateResourceType(int id, [FromBody] UpdateResourceTypeViewModel model)
        {
            var result = await _resourceTypeService.UpdateResourceType(id, model);
            
            return result.ToJsonResult();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteResourceType(int id)
        {
            var result = await _resourceTypeService.DeleteResourceType(id);
            
            return result.ToJsonResult();
        }
    }
}