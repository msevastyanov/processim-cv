using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProcessSIM.Domain.Entities;
using ProcessSIM.Infrastructure.Data;
using ProcessSIM.Infrastructure.Extensions;

namespace ProcessSIM.Infrastructure.Repositories
{
    public class ResourceTypeRepository : IResourceTypeRepository
    {
        private readonly SimContext _db;
        
        public ResourceTypeRepository(SimContext db)
        {
            _db = db;
        }

        public async Task<List<ResourceType>> GetAllResourceTypes()
        {
            return await _db.ResourceType.Include(x => x.ResourceCategory).Include(x => x.ResourceParameters).ToListAsync();
        }

        public async Task<ResourceType> FindResourceType(int typeId, bool isIncludes)
        {
            return await _db.ResourceType.ResourceTypeInclude(isIncludes).SingleOrDefaultAsync(x => x.ResourceTypeId == typeId);
        }

        public async Task<ResourceType> FindResourceTypeByName(string name)
        {
            return await _db.ResourceType
                .SingleOrDefaultAsync(x => x.ResourceTypeName == name);
        }

        public async Task<List<ResourceType>> GetResourceTypesByCategory(int resCategoryId)
        {
            return await _db.ResourceType.Include(x => x.ResourceCategory).Include(x => x.ResourceParameters).Where(x => x.ResourceCategory.ResourceCategoryId == resCategoryId).ToListAsync();
        }

        public async Task AddResourceType(ResourceType type)
        {
            await _db.ResourceType.AddAsync(type);
            
            await _db.SaveChangesAsync();
        }

        public async Task UpdateResourceType(ResourceType type)
        {
            _db.Update(type);
            
            await _db.SaveChangesAsync();
        }

        public async Task DeleteResourceType(int resourceId)
        {
            var type = await _db.ResourceType.SingleOrDefaultAsync(x => x.ResourceTypeId == resourceId);
            
            if (type != null)
                _db.ResourceType.Remove(type);
            
            await _db.SaveChangesAsync();
        }
    }
}