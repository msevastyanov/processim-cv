using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProcessSIM.Application.Extensions;
using ProcessSIM.ServiceLayer.Services;
using ProcessSIM.ServiceLayer.ViewModels.ResourceCategories;

namespace ProcessSIM.Application.Controllers
{
    [Route("api/category")]
    [Authorize]
    [ApiController]
    public class ResourceCategoryController : Controller
    {
        private readonly IResourceCategoryService _resourceCategoryService;

        public ResourceCategoryController(IResourceCategoryService resourceCategoryService)
        {
            _resourceCategoryService = resourceCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetResourceCategories()
        {
            var resCategories = await _resourceCategoryService.GetAllResourceCategories();
            return Json(new {resCategories});
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateResourceCategory([FromBody] CreateResourceCategoryViewModel model)
        {
            var result = await _resourceCategoryService.AddResourceCategory(model);

            return result.ToJsonResult();
        }

        [HttpPost("{id}/update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateResourceCategory(int id,
            [FromBody] UpdateResourceCategoryViewModel model)
        {
            var result = await _resourceCategoryService.UpdateResourceCategory(id, model);

            return result.ToJsonResult();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteResourceCategory(int id)
        {
            var result = await _resourceCategoryService.DeleteResourceCategory(id);

            return result.ToJsonResult();
        }
    }
}