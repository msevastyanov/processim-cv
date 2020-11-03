using System.Threading.Tasks;
using ProcessSIM.Domain.Auth;
using ProcessSIM.ServiceLayer.Models;
using ProcessSIM.ServiceLayer.ViewModels.Users;

namespace ProcessSIM.ServiceLayer.Services
{
    public interface IUserService
    {
        Task<RequestResult<ApplicationUser>> CreateAccount(CreateUserViewModel model);
        Task<RequestResult<ApplicationUser>> CreateUserAccount(CreateUserViewModel model, string role);
        Task<RequestResult<ApplicationUser>> RemoveAccount(string username);
        Task<RequestResult<ApplicationUser>> ResetPassword(string username, string newPassword);
    }
}