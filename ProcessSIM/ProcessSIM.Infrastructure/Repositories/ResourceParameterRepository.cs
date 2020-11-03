using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProcessSIM.Domain.Entities;
using ProcessSIM.Infrastructure.Data;

namespace ProcessSIM.Infrastructure.Repositories
{
    public class ResourceParameterRepository : IResourceParameterRepository
    {
        private readonly SimContext _db;
        
        public ResourceParameterRepository(SimContext db)
        {
            _db = db;
        }

        public async Task<List<ResourceParameter>> GetAllResourceParameters()
        {
            return await _db.ResourceParameter.Include(x => x.ResourceType).ToListAsync();
        }

        public async Task<ResourceParameter> FindResourceParameter(int paramId)
        {
            return await _db.ResourceParameter.FindAsync(paramId);
        }

        public async Task<List<ResourceParameter>> GetResourceParametersByType(int resTypeId)
        {
            return await _db.ResourceParameter.Include(x => x.ResourceType).Where(x => x.ResourceType.ResourceTypeId == resTypeId).ToListAsync();
        }

        public async Task AddResourceParameter(ResourceParameter parameter)
        {
            await _db.ResourceParameter.AddAsync(parameter);
            
            await _db.SaveChangesAsync();
        }

        public async Task UpdateResourceParameter(ResourceParameter parameter)
        {
            _db.Update(parameter);
            
            await _db.SaveChangesAsync();
        }

        public async Task DeleteResourceParameter(int parameterId)
        {
            var parameter = await _db.ResourceParameter.SingleOrDefaultAsync(x => x.ResourceParameterId == parameterId);
            
            if (parameter != null)
                _db.ResourceParameter.Remove(parameter);
            
            await _db.SaveChangesAsync();
        }

        public async Task DeleteResourceParametersByResourceType(int resourceTypeId)
        {
            var parameters = await GetResourceParametersByType(resourceTypeId);
            
            if (parameters.Any())
                _db.ResourceParameter.RemoveRange(parameters);
            
            await _db.SaveChangesAsync();
        }
    }
}