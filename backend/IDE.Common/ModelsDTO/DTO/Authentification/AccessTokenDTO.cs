using IDE.Common.Authentication;

namespace IDE.Common.ModelsDTO.DTO.Authentification
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
