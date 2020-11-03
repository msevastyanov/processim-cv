using System.ComponentModel.DataAnnotations;

namespace ProcessSIM.ServiceLayer.ViewModels.Auth
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}