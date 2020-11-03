using System.Collections.Generic;
using System.Threading.Tasks;
using ProcessSIM.Domain.Entities;

namespace ProcessSIM.Infrastructure.Repositories
{
    public interface IResourceTypeRepository
    {
        Task<List<ResourceType>> GetAllResourceTypes();
        Task<ResourceType> FindResourceType(int typeId, bool isIncludes);
        Task<ResourceType> FindResourceTypeByName(string name);
        Task<List<ResourceType>> GetResourceTypesByCategory(int resCategoryId);
        Task AddResourceType(ResourceType type);
        Task UpdateResourceType(ResourceType type);
        Task DeleteResourceType(int resourceId);
    }
}