using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProcessSIM.Domain.Auth;
using ProcessSIM.ServiceLayer.Models;
using ProcessSIM.ServiceLayer.ViewModels.Users;

namespace ProcessSIM.ServiceLayer.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IUserClaimsProvider _claimsProvider;

        public UserService(UserManager<ApplicationUser> userManager,
            IUserClaimsProvider claimsProvider)
        {
            _userManager = userManager;
            _claimsProvider = claimsProvider;
        }

        public async Task<RequestResult<ApplicationUser>> CreateAccount(CreateUserViewModel model)
        {
            var existingUser = await _userManager.FindByNameAsync(model.Username);
            if (existingUser != null)
                return RequestResult<ApplicationUser>.Failed("Пользователь с таким именем уже существует");

            var user = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.Username,
                PhoneNumber = null,
                PhoneNumberConfirmed = true,
                Email = null,
                EmailConfirmed = true,
                TwoFactorEnabled = false,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var creationResult = await _userManager.CreateAsync(user, model.Password);
            if (!creationResult.Succeeded)
                return RequestResult<ApplicationUser>.Failed(creationResult.Errors.First().Description);

            var claims = _claimsProvider.GenerateClaims(user);

            var addClaimsResult = await _userManager.AddClaimsAsync(user, claims);

            if (!addClaimsResult.Succeeded)
                return RequestResult<ApplicationUser>.Failed(addClaimsResult.Errors.First().Description);

            return RequestResult<ApplicationUser>.Success(user);
        }

        public async Task<RequestResult<ApplicationUser>> RemoveAccount(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            await _userManager.RemoveFromRoleAsync(user, ApplicationUserRoles.UserRole);
            await _userManager.DeleteAsync(user);

            return RequestResult<ApplicationUser>.Success(user);
        }

        public async Task<RequestResult<ApplicationUser>> CreateUserAccount(CreateUserViewModel model,
            string role)
        {
            var userCreationResult = await CreateAccount(model);
            if (!userCreationResult.Succeeded)
                return userCreationResult;

            if (await _userManager.IsInRoleAsync(userCreationResult.Content, role))
                return RequestResult<ApplicationUser>.Success(userCreationResult.Content);
            
            var addToRoleResult = await _userManager.AddToRoleAsync(userCreationResult.Content, role);
            if (!addToRoleResult.Succeeded)
                return RequestResult<ApplicationUser>.Failed(addToRoleResult.Errors.Select(e => e.Description)
                    .First());

            return RequestResult<ApplicationUser>.Success(userCreationResult.Content);
        }

        public async Task<RequestResult<ApplicationUser>> ResetPassword(string username, string newPassword)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
                return RequestResult<ApplicationUser>.Failed("Такого пользователя не существует");

            var resetToken = _userManager.GeneratePasswordResetTokenAsync(user).Result;

            var changingResult = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
            return !changingResult.Succeeded
                ? RequestResult<ApplicationUser>.Failed(changingResult.Errors.First().Description)
                : RequestResult<ApplicationUser>.Success(user);
        }
    }
}