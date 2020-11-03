using System.Collections.Generic;
using System.Security.Claims;
using ProcessSIM.Domain.Auth;

namespace ProcessSIM.ServiceLayer.Services
{
    public interface IUserClaimsProvider
    {
        List<Claim> GenerateClaims(ApplicationUser user);
    }
}