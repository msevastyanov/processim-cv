using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProcessSIM.Domain.Entities;
using ProcessSIM.Infrastructure.Data;
using ProcessSIM.Infrastructure.Repositories;

namespace ProcessSIM.Infrastructure.Configuration
{
    public class RepositoriesConfig
    {
        public static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddTransient<IResourceCategoryRepository, ResourceCategoryRepository>();
            services.AddTransient<IResourceTypeRepository, ResourceTypeRepository>();
            services.AddTransient<IResourceParameterRepository, ResourceParameterRepository>();
            services.AddTransient<IResourceRepository, ResourceRepository>();
            services.AddTransient<IResourceParameterValueRepository, ResourceParameterValueRepository>();
            services.AddTransient<ISimulationHistoryRepository, SimulationHistoryRepository>();
            services.AddTransient<ISimulationNameRepository, SimulationNameRepository>();
        }
    }
}