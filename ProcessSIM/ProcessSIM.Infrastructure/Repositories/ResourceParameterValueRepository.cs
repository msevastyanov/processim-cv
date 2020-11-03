using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProcessSIM.Domain.Entities;
using ProcessSIM.Infrastructure.Data;

namespace ProcessSIM.Infrastructure.Repositories
{
    public class ResourceParameterValueRepository : IResourceParameterValueRepository
    {
        private readonly SimContext _db;

        public ResourceParameterValueRepository(SimContext db)
        {
            _db = db;
        }

        public async Task<List<ResourceParameterValue>> GetAllResourceParameterValues()
        {
            return await _db.ResourceParameterValue.Include(x => x.ResourceParameter).Include(x => x.Resource)
                .ToListAsync();
        }

        public async Task<List<ResourceParameterValue>> GetResourceParameterValuesByResource(int resId)
        {
            return await _db.ResourceParameterValue.Include(x => x.ResourceParameter).Include(x => x.Resource)
                .Where(x => x.Resource.ResourceId == resId).ToListAsync();
        }

        public async Task<List<ResourceParameterValue>> GetResourceParameterValuesByParameter(int paramId)
        {
            return await _db.ResourceParameterValue.Include(x => x.ResourceParameter)
                .Where(x => x.ResourceParameter.ResourceParameterId == paramId).ToListAsync();
        }

        public async Task<ResourceParameterValue> FindResourceParameterValue(int paramValueId)
        {
            return await _db.ResourceParameterValue.Include(x => x.ResourceParameter).SingleOrDefaultAsync(
                x => x.ResourceParameterValueId == paramValueId);
        }

        public async Task<ResourceParameterValue> FindResourceParameterValue(int paramId, int resourceId)
        {
            return await _db.ResourceParameterValue.Include(x => x.ResourceParameter).Include(x => x.Resource)
                .SingleOrDefaultAsync(x => x.ResourceParameter.ResourceParameterId == paramId && x.Resource.ResourceId == resourceId);
        }

        public async Task AddResourceParameterValue(ResourceParameterValue parameterValue)
        {
            await _db.ResourceParameterValue.AddAsync(parameterValue);

            await _db.SaveChangesAsync();
        }

        public async Task AddResourceParameterValues(IEnumerable<ResourceParameterValue> parameterValues)
        {
            await _db.ResourceParameterValue.AddRangeAsync(parameterValues);

            await _db.SaveChangesAsync();
        }

        public async Task UpdateResourceParameterValue(ResourceParameterValue parameterValue)
        {
            _db.Update(parameterValue);

            await _db.SaveChangesAsync();
        }

        public async Task DeleteResourceParameterValue(int resourceId)
        {
            var parameterValue =
                await _db.ResourceParameterValue.SingleOrDefaultAsync(x => x.ResourceParameterValueId == resourceId);

            if (parameterValue != null)
                _db.ResourceParameterValue.Remove(parameterValue);

            await _db.SaveChangesAsync();
        }

        public async Task DeleteResourceParameterValues(int resourceParametersId)
        {
            var paramValues = await GetResourceParameterValuesByParameter(resourceParametersId);

            if (paramValues.Any())
                _db.ResourceParameterValue.RemoveRange(paramValues);

            await _db.SaveChangesAsync();
        }

        public async Task DeleteResourceParameterValuesByResource(int resourceId)
        {
            var paramValues = await GetResourceParameterValuesByResource(resourceId);

            if (paramValues.Any())
                _db.ResourceParameterValue.RemoveRange(paramValues);

            await _db.SaveChangesAsync();
        }
    }
}