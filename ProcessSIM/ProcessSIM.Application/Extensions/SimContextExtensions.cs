using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProcessSIM.Domain.Auth;
using ProcessSIM.Infrastructure.Data;
using ProcessSIM.ServiceLayer.Services;
using ProcessSIM.ServiceLayer.ViewModels.ResourceCategories;
using ProcessSIM.ServiceLayer.ViewModels.ResourceParameters;
using ProcessSIM.ServiceLayer.ViewModels.ResourceParameterValues;
using ProcessSIM.ServiceLayer.ViewModels.Resources;
using ProcessSIM.ServiceLayer.ViewModels.ResourceTypes;
using ProcessSIM.ServiceLayer.ViewModels.Users;

namespace ProcessSIM.Application.Extensions
{
    public static class SimContextExtensions
    {
        public static void EnsureSeeds(this SimContext context, IUserService userService,
            RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(context, roleManager);
            SeedUsers(context, userService);
        }

        private static void SeedRoles(SimContext context, RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync(ApplicationUserRoles.UserRole).Result)
            {
                roleManager.CreateAsync(new IdentityRole(ApplicationUserRoles.UserRole)).Wait();
            }

            if (!roleManager.RoleExistsAsync(ApplicationUserRoles.AdminRole).Result)
            {
                roleManager.CreateAsync(new IdentityRole(ApplicationUserRoles.AdminRole)).Wait();
            }
        }

        private static void SeedUsers(SimContext context, IUserService userService)
        {
            if (context.Users.Any()) return;

            userService.CreateUserAccount(
                new CreateUserViewModel
                { Username = "TestUser", FirstName = "User", LastName = "User", Password = "user123" },
                ApplicationUserRoles.UserRole).Wait();

            userService.CreateUserAccount(
                new CreateUserViewModel
                { Username = "TestAdmin", FirstName = "Admin", LastName = "Admin", Password = "admin123" },
                ApplicationUserRoles.AdminRole).Wait();
        }
    }
}