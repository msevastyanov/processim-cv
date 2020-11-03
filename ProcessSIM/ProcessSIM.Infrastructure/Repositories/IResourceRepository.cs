using System.Collections.Generic;
using System.Threading.Tasks;
using ProcessSIM.Domain.Entities;

namespace ProcessSIM.Infrastructure.Repositories
{
    public interface IResourceRepository
    {
        Task<List<Resource>> GetAllResources();
        Task<List<Resource>> GetResourcesByType(int resTypeId);
        Task<Resource> FindResource(int resourceId, bool isIncludes);
        Task<Resource> FindResourceByName(string name);
        Task AddResource(Resource resource);
        Task UpdateResource(Resource resource);
        Task DeleteResource(int resourceId);
    }
}