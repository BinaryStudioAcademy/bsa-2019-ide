using IDE.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.Common.ModelsDTO.DTO.User
{
    public class UpdateUserRightDTO
    {
        public int ProjectId { get; set; }
        public UserAccess Access { get; set; }
        public int UserId { get; set; }
    }
}
