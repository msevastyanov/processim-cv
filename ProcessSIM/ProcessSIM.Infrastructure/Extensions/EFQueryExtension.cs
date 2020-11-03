using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProcessSIM.Domain.Entities;

namespace ProcessSIM.Infrastructure.Extensions
{
    public static class EFQueryExtension
    {
        public static IQueryable<ResourceCategory> ResourceCategoryInclude(this DbSet<ResourceCategory> resCategories,
            bool isIncludes)
        {
            return isIncludes
                ? resCategories.Include(x => x.ResourceTypes).Include(x => x.Resources)
                : resCategories.AsQueryable();
        }

        public static IQueryable<ResourceType> ResourceTypeInclude(this DbSet<ResourceType> resTypes, bool isIncludes)
        {
            return isIncludes
                ? resTypes.Include(x => x.Resources).Include(x => x.ResourceParameters)
                : resTypes.AsQueryable();
        }

        public static IQueryable<Resource> ResourceInclude(this DbSet<Resource> resources, bool isIncludes)
        {
            return isIncludes
                ? resources.Include(x => x.ResourceParameterValues)
                : resources.AsQueryable();
        }
    }
}