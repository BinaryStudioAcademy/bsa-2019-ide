using IDE.Common.Authentification;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.Common.DTO.Authentification
{
    public class AccessTokenDTO
    {
        public AccessToken AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public AccessTokenDTO(AccessToken accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
