using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.Common.DTO.User
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Salt { get; set; }
    }
}
