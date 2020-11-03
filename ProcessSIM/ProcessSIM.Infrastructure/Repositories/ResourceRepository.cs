using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProcessSIM.Domain.Entities;
using ProcessSIM.Infrastructure.Data;
using ProcessSIM.Infrastructure.Extensions;

namespace ProcessSIM.Infrastructure.Repositories
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly SimContext _db;
        
        public ResourceRepository(SimContext db)
        {
            _db = db;
        }

        public async Task<List<Resource>> GetAllResources()
        {
            return await _db.Resource.Include(x => x.ResourceCategory).Include(x => x.ResourceType).Include(x => x.ResourceParameterValues).ThenInclude(x => x.ResourceParameter).ToListAsync();
        }

        public async Task<List<Resource>> GetResourcesByType(int resTypeId)
        {
            return await _db.Resource.Include(x => x.ResourceCategory).Include(x => x.ResourceType).Where(x => x.ResourceType.ResourceTypeId == resTypeId).ToListAsync();
        }

        public async Task<Resource> FindResource(int resourceId, bool isIncludes)
        {
            return await _db.Resource.ResourceInclude(isIncludes).SingleOrDefaultAsync(x => x.ResourceId == resourceId);
        }
        
        public async Task<Resource> FindResourceByName(string name)
        {
            return await _db.Resource
                .SingleOrDefaultAsync(x => x.ResourceName == name);
        }

        public async Task AddResource(Resource resource)
        {
            await _db.Resource.AddAsync(resource);
            
            await _db.SaveChangesAsync();
        }

        public async Task UpdateResource(Resource resource)
        {
            _db.Update(resource);
            
            await _db.SaveChangesAsync();
        }

        public async Task DeleteResource(int resourceId)
        {
            var resource = await _db.Resource.SingleOrDefaultAsync(x => x.ResourceId == resourceId);
            
            if (resource != null)
                _db.Resource.Remove(resource);
            
            await _db.SaveChangesAsync();
        }
    }
}