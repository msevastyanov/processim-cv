using System.Collections.Generic;
using System.Threading.Tasks;
using ProcessSIM.ServiceLayer.Models;
using ProcessSIM.ServiceLayer.ViewModels.ResourceParameters;

namespace ProcessSIM.ServiceLayer.Services
{
    public interface IResourceParameterService
    {
        Task<List<ResourceParameterViewModel>> GetResourceParametersByResourceType(int resTypeId);
        Task<RequestResult<ResourceParameterViewModel>> AddResourceParameter(int resTypeId,
            CreateResourceParameterViewModel parameterViewModel);

        Task<RequestResult<ResourceParameterViewModel>> UpdateResourceParameter(int resTypeId, int resParamId,
            UpdateResourceParameterViewModel parameterViewModel);
        Task<RequestResult> DeleteResourceParameter(int paramId);
    }
}