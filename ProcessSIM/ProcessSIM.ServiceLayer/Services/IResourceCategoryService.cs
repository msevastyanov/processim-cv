using System.Collections.Generic;
using System.Threading.Tasks;
using ProcessSIM.Domain.Entities;
using ProcessSIM.ServiceLayer.Models;
using ProcessSIM.ServiceLayer.ViewModels.ResourceCategories;

namespace ProcessSIM.ServiceLayer.Services
{
    public interface IResourceCategoryService
    {
        Task<List<ResourceCategoryViewModel>> GetAllResourceCategories();
        Task<RequestResult<ResourceCategoryViewModel>> AddResourceCategory(CreateResourceCategoryViewModel categoryViewModel);
        Task<RequestResult<ResourceCategoryViewModel>> UpdateResourceCategory(int catId, UpdateResourceCategoryViewModel categoryViewModel);
        Task<RequestResult> DeleteResourceCategory(int catId);
    }
}