using IDE.Common.ModelsDTO.DTO.Authentification;

namespace IDE.Common.DTO.User
{
    public class AuthUserDTO
    {
        public AccessTokenDTO Token { get; set; }
        public UserDTO User { get; set; }
    }
}
