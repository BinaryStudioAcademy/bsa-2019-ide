using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.DAL.Entities
{
    public class RefreshToken
    {

        private const int DAYS_TO_EXPIRE = 5;

        public RefreshToken()
        {
            Expires = DateTime.UtcNow.AddDays(DAYS_TO_EXPIRE);
        }

        public string Token { get; set; }
        public DateTime Expires { get; private set; }

        public int UserId { get; set; }
        public BaseUser User { get; set; }

        public bool IsActive => DateTime.UtcNow <= Expires;
    }
}
