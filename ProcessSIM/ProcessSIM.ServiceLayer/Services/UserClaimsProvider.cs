using System.Collections.Generic;
using System.Security.Claims;
using ProcessSIM.Domain.Auth;

namespace ProcessSIM.ServiceLayer.Services
{
    public class UserClaimsProvider : IUserClaimsProvider
    {
        public List<Claim> GenerateClaims(ApplicationUser user)
        {
            return new List<Claim>()
            {
                new Claim(System.Security.Claims.ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName)
            };
        }
    }
}