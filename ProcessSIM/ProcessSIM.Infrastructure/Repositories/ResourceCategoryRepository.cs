using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProcessSIM.Domain.Entities;
using ProcessSIM.Infrastructure.Data;
using ProcessSIM.Infrastructure.Extensions;

namespace ProcessSIM.Infrastructure.Repositories
{
    public class ResourceCategoryRepository : IResourceCategoryRepository
    {
        private readonly SimContext _db;

        public ResourceCategoryRepository(SimContext db)
        {
            _db = db;
        }

        public async Task<List<ResourceCategory>> GetAllResourceCategories()
        {
            return await _db.ResourceCategory.Include(x => x.ResourceTypes).ToListAsync();
        }

        public async Task<ResourceCategory> FindResourceCategory(int catId, bool isIncludes)
        {
            return await _db.ResourceCategory.ResourceCategoryInclude(isIncludes)
                .SingleOrDefaultAsync(x => x.ResourceCategoryId == catId);
        }

        public async Task<ResourceCategory> FindResourceCategoryByName(string name)
        {
            return await _db.ResourceCategory
                .SingleOrDefaultAsync(x => x.ResourceCategoryName == name);
        }

        public async Task AddResourceCategory(ResourceCategory category)
        {
            await _db.ResourceCategory.AddAsync(category);

            await _db.SaveChangesAsync();
        }

        public async Task UpdateResourceCategory(ResourceCategory category)
        {
            _db.Update(category);

            await _db.SaveChangesAsync();
        }

        public async Task DeleteResourceCategory(int resourceId)
        {
            var category = await _db.ResourceCategory.SingleOrDefaultAsync(x => x.ResourceCategoryId == resourceId);

            if (category != null)
                _db.ResourceCategory.Remove(category);

            await _db.SaveChangesAsync();
        }
    }
}