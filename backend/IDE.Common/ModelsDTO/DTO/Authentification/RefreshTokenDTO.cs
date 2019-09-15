using System;
using Newtonsoft.Json;

namespace IDE.Common.ModelsDTO.DTO.Authentification
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
