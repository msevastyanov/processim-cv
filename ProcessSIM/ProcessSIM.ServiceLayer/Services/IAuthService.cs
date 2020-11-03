using System.Threading.Tasks;
using ProcessSIM.ServiceLayer.Models;
using ProcessSIM.ServiceLayer.ViewModels.Auth;

namespace ProcessSIM.ServiceLayer.Services
{
    public interface IAuthService
    {
        Task<RequestResult<LoginResultViewModel>> Login(LoginViewModel model);
    }
}