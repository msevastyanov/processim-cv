using ProcessSIM.Domain.Auth;

namespace ProcessSIM.ServiceLayer.ViewModels.Auth
{
    public class LoginResultViewModel
    {
        public AuthToken AccessToken { get; set; }
        public UserInfoViewModel UserInfo { get; set; }
    }
}