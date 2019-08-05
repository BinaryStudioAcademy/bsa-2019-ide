using IDE.Common.DTO.Authentification;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.Common.DTO.User
{
    public class AuthUserDTO
    {
        public AccessTokenDTO Token { get; set; }
        public UserDTO User { get; set; }
    }
}
