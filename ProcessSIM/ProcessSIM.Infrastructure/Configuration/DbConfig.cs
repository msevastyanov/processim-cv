using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProcessSIM.Infrastructure.Data;

namespace ProcessSIM.Infrastructure.Configuration
{
    public static class DbConfig
    {
        public static void ConfigureDb(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SimContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("ProcessSIM.Application")));
        }
    }
}