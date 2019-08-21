using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.DAL.Entities
{
    public class VerificationToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
