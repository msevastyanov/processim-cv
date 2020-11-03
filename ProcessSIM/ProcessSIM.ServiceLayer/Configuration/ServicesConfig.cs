using Microsoft.Extensions.DependencyInjection;
using ProcessSIM.Domain.Entities.History;
using ProcessSIM.Infrastructure.Repositories;
using ProcessSIM.ServiceLayer.Services;

namespace ProcessSIM.ServiceLayer.Configuration
{
    public class ServicesConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IProcedureService, ProcedureService>();
            services.AddTransient<IResourceCategoryService, ResourceCategoryService>();
            services.AddTransient<IResourceTypeService, ResourceTypeService>();
            services.AddTransient<IResourceParameterService, ResourceParameterService>();
            services.AddTransient<IResourceService, ResourceService>();
            services.AddTransient<IResourceParameterValueService, ResourceParameterValueService>();
            services.AddTransient<ISimulationService, SimulationService>();
            services.AddTransient<ISimulationHistoryService, SimulationHistoryService>();
            services.AddTransient<ITokenProvider, TokenProvider>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserClaimsProvider, UserClaimsProvider>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}