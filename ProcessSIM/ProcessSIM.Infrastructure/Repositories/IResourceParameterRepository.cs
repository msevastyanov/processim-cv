using System.Collections.Generic;
using System.Threading.Tasks;
using ProcessSIM.Domain.Entities;

namespace ProcessSIM.Infrastructure.Repositories
{
    public interface IResourceParameterRepository
    {
        Task<List<ResourceParameter>> GetAllResourceParameters();
        Task<ResourceParameter> FindResourceParameter(int paramId);
        Task<List<ResourceParameter>> GetResourceParametersByType(int resTypeId);
        Task AddResourceParameter(ResourceParameter parameter);
        Task UpdateResourceParameter(ResourceParameter parameter);
        Task DeleteResourceParameter(int resourceId);
        Task DeleteResourceParametersByResourceType(int resourceTypeId);
    }
}