using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.Common.Authentification
{
    public class AccessToken
    {
        public string Token { get; }
        public int ExpiresIn { get; }

        public AccessToken(string token, int expiresIn)
        {
            Token = token;
            ExpiresIn = expiresIn;
        }
    }
}
