using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProcessSIM.Application.Extensions;
using ProcessSIM.Infrastructure.Data;
using ProcessSIM.ServiceLayer.Services;

namespace ProcessSIM.Application
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IHost webHost = CreateHostBuilder(args).Build();

            using var scope = webHost.Services.CreateScope();
            // Get the DbContext instance
            // var myDbContext = scope.ServiceProvider.GetRequiredService<SimContext>();
            // var resourceCategoryService =
            //     scope.ServiceProvider.GetRequiredService<IResourceCategoryService>();
            // var resourceTypeService =
            //     scope.ServiceProvider.GetRequiredService<IResourceTypeService>();
            // var resourceService =
            //     scope.ServiceProvider.GetRequiredService<IResourceService>();
            // var resourceParameterService =
            //     scope.ServiceProvider.GetRequiredService<IResourceParameterService>();
            // var resourceParameterValueServic =
            //     scope.ServiceProvider.GetRequiredService<IResourceParameterValueService>();
            // var resourceParameterService =
            //     scope.ServiceProvider.GetRequiredService<IResourceParameterService>();
            // var resourceParameterValueServic =
            //     scope.ServiceProvider.GetRequiredService<IResourceParameterValueService>();
            //
            // //Do the migration asynchronously
            // await myDbContext.EnsureSeeds(resourceCategoryService, resourceTypeService, resourceService,
            //     resourceParameterService, resourceParameterValueServic);
                
            await webHost.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}