using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProcessSIM.Application.Extensions;
using ProcessSIM.ServiceLayer.Services;
using ProcessSIM.ServiceLayer.ViewModels.Auth;

namespace ProcessSIM.Application.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { status = "fail", message = "bad request" });

            var loginResult = await _authService.Login(model);

            return loginResult.ToJsonResult();
        }
    }
}