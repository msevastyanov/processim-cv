using System.Collections.Generic;
using System.Threading.Tasks;
using ProcessSIM.ServiceLayer.Models;
using ProcessSIM.ServiceLayer.ViewModels.ResourceTypes;

namespace ProcessSIM.ServiceLayer.Services
{
    public interface IResourceTypeService
    {
        Task<RequestResult<ResourceTypeViewModel>> GetResourceType(int resTypeId);
        Task<RequestResult<ResourceTypeViewModel>> AddResourceType(int resCatId, CreateResourceTypeViewModel typeViewModel);
        Task<RequestResult<ResourceTypeViewModel>> UpdateResourceType(int typeId, UpdateResourceTypeViewModel typeViewModel);
        Task<RequestResult> DeleteResourceType(int typeId);
    }
}