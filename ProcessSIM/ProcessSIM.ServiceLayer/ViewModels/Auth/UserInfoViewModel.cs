using ProcessSIM.Domain.Auth;

namespace ProcessSIM.ServiceLayer.ViewModels.Auth
{
    public class UserInfoViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserInfoViewModel() { }

        public UserInfoViewModel(ApplicationUser user)
        {
            Id = user.Id;
            Name = user.UserName;
            FirstName = user.FirstName;
            LastName = user.LastName;
        }
    }
}