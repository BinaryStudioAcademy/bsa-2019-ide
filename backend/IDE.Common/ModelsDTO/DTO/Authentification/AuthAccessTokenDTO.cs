using IDE.Common.Authentication;

namespace IDE.Common.ModelsDTO.DTO.Authentification
{
    public class AuthAccessTokenDTO
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string token_type { get; set; }
    }
}
