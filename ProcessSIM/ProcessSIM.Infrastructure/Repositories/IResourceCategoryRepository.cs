using System.Collections.Generic;
using System.Threading.Tasks;
using ProcessSIM.Domain.Entities;

namespace ProcessSIM.Infrastructure.Repositories
{
    public interface IResourceCategoryRepository
    {
        Task<List<ResourceCategory>> GetAllResourceCategories();
        Task<ResourceCategory> FindResourceCategory(int catId, bool isIncludes);
        Task<ResourceCategory> FindResourceCategoryByName(string name);
        Task AddResourceCategory(ResourceCategory category);
        Task UpdateResourceCategory(ResourceCategory category);
        Task DeleteResourceCategory(int resourceId);
    }
}