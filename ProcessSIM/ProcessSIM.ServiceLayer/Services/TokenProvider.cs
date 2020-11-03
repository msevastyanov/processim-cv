using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProcessSIM.Domain.Auth;

namespace ProcessSIM.ServiceLayer.Services
{
    public class TokenProvider : ITokenProvider
    {
        private readonly AuthTokenOptions _authTokenOptions;
        private readonly UserManager<ApplicationUser> _userManager;

        public TokenProvider(UserManager<ApplicationUser> userManager,
            IOptions<AuthTokenOptions> authTokenOptions)
        {
            _userManager = userManager;
            _authTokenOptions = authTokenOptions.Value;
        }

        public async Task<AuthToken> Create(ApplicationUser user)
        {
            if (user == null)
                throw new ArgumentNullException($"Name: {nameof(user)}. Method: {nameof(Create)})");

            var roles = await _userManager.GetRolesAsync(user);
            var claims = await _userManager.GetClaimsAsync(user);
            var roleClaims = new List<Claim>(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));

            var jwt = new JwtSecurityToken(
                issuer: _authTokenOptions.Issuer,
                audience: _authTokenOptions.Audience,
                notBefore: DateTime.UtcNow,
                claims: claims.Concat(roleClaims),
                expires: DateTime.UtcNow.Add(_authTokenOptions.AccessTokenLifetime),
                signingCredentials: new SigningCredentials(_authTokenOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new AuthToken
            {
                Value = encodedJwt,
                ExpirationTime = _authTokenOptions.AccessTokenLifetime
            };
        }
    }
}