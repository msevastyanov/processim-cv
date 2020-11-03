using System.Collections.Generic;
using System.Threading.Tasks;
using ProcessSIM.Domain.Entities;

namespace ProcessSIM.Infrastructure.Repositories
{
    public interface IResourceParameterValueRepository
    {
        Task<List<ResourceParameterValue>> GetAllResourceParameterValues();
        Task<List<ResourceParameterValue>> GetResourceParameterValuesByResource(int resId);
        Task<List<ResourceParameterValue>> GetResourceParameterValuesByParameter(int paramId);
        Task<ResourceParameterValue> FindResourceParameterValue(int paramValueId);
        Task<ResourceParameterValue> FindResourceParameterValue(int paramId, int resourceId);
        Task AddResourceParameterValue(ResourceParameterValue parameterValue);
        Task AddResourceParameterValues(IEnumerable<ResourceParameterValue> parameterValues);
        Task UpdateResourceParameterValue(ResourceParameterValue parameterValue);
        Task DeleteResourceParameterValue(int resourceId);
        Task DeleteResourceParameterValues(int resourceParametersId);
        Task DeleteResourceParameterValuesByResource(int resourceId);
    }
}