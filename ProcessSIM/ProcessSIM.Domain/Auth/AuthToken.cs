using System;

namespace ProcessSIM.Domain.Auth
{
    public class AuthToken
    {
        public string Value { get; set; }

        public TimeSpan ExpirationTime { get; set; }
    }
}