using System;

namespace IDE.DAL.Entities
{
    public class RefreshToken
    {

        public int Id { get; set; }

        private const int DAYS_TO_EXPIRE = 5;

        public RefreshToken()
        {
            Expires = DateTime.UtcNow.AddDays(DAYS_TO_EXPIRE);
        }

        public string Token { get; set; }
        public DateTime Expires { get; private set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public bool IsActive => DateTime.UtcNow <= Expires;
    }
}
