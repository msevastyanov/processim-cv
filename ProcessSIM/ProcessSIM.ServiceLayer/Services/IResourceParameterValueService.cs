using System.Collections.Generic;
using System.Threading.Tasks;
using ProcessSIM.ServiceLayer.Models;
using ProcessSIM.ServiceLayer.ViewModels.ResourceParameterValues;

namespace ProcessSIM.ServiceLayer.Services
{
    public interface IResourceParameterValueService
    {
        Task<List<ResourceParameterValueViewModel>> GetResourceParametersByResource(int resId);

        Task<RequestResult<ResourceParameterValueViewModel>>
            GetResourceParameterValue(int paramId, int resourceId);

        Task<RequestResult<ResourceParameterValueViewModel>>
            UpdateResourceParameterValue(int paramValueId, UpdateResourceParameterValueViewModel paramValueViewModel);
    }
}