using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.DAL.Entities
{
    public class BaseUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
