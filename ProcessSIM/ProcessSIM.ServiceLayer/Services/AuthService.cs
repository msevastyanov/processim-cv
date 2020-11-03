using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProcessSIM.Domain.Auth;
using ProcessSIM.ServiceLayer.Models;
using ProcessSIM.ServiceLayer.ViewModels.Auth;

namespace ProcessSIM.ServiceLayer.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenProvider _tokenProvider;

        public AuthService(UserManager<ApplicationUser> userManager, ITokenProvider tokenProvider)
        {
            _userManager = userManager;
            _tokenProvider = tokenProvider;
        }

        public async Task<RequestResult<LoginResultViewModel>> Login(LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
                return RequestResult<LoginResultViewModel>.Failed("Неверный логин или пароль");

            if (await _userManager.IsLockedOutAsync(user))
                return RequestResult<LoginResultViewModel>.Failed("Пользователь заблокирован");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!isPasswordValid)
            {
                await _userManager.AccessFailedAsync(user);
                return RequestResult<LoginResultViewModel>.Failed("Неверный логин или пароль");
            }

            var resetResult = await _userManager.ResetAccessFailedCountAsync(user);
            if (!resetResult.Succeeded)
                return RequestResult<LoginResultViewModel>.Failed(resetResult.Errors.First().Description);

            return RequestResult<LoginResultViewModel>.Success(new LoginResultViewModel
            {
                AccessToken = await _tokenProvider.Create(user),
                UserInfo = new UserInfoViewModel(user)
            });
        }
    }
}