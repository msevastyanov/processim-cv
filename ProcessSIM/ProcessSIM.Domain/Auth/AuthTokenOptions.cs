using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ProcessSIM.Domain.Auth
{
    public class AuthTokenOptions
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public TimeSpan AccessTokenLifetime { get; set; }

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}