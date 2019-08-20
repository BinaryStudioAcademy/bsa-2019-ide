using IDE.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.Common.ModelsDTO.DTO.User
{
    public class CollaboratorDTO: UserNicknameDTO
    {
        public UserAccess Access { get; set; }
    }
}
