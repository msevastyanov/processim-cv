using System.Collections.Generic;
using System.Threading.Tasks;
using ProcessSIM.ServiceLayer.Models;
using ProcessSIM.ServiceLayer.ViewModels.Resources;

namespace ProcessSIM.ServiceLayer.Services
{
    public interface IResourceService
    {
        Task<List<ResourceViewModel>> GetAllResources();
        Task<List<ResourceViewModel>> GetResourcesByType(int typeId);
        Task<RequestResult<ResourceViewModel>> AddResource(int typeId, CreateResourceViewModel resourceViewModel);

        Task<RequestResult<ResourceViewModel>>
            UpdateResource(int resourceId, UpdateResourceViewModel resourceViewModel);

        Task<RequestResult> DeleteResource(int resourceId);
    }
}