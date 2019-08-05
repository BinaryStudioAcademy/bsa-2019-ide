using IDE.Common.Authentification;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.Common.DTO.Authentification
{
    public class RefreshTokenDTO
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        [JsonIgnore]
        public string Key { get; private set; }

        public RefreshTokenDTO()
        {
            Key = Environment.GetEnvironmentVariable("SecretJWTKey");
        }
    }
}
