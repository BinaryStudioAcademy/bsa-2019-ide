using IDE.BLL.ExceptionsCustom;
using IDE.BLL.Interfaces;
using IDE.DAL.Context;
using IDE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace IDE.BLL.Services
{
    public class TokenService : ITokenService
    {
        private readonly IdeContext _context;
        private int userId;
        public string FirstName { get; private set; }
        private User user;

        public TokenService(IdeContext context)
        {
            _context = context;
        }

        public User GetUser()
        {
            if (userId == 0)
            {
                ThrowException();
            }

            if (!CheckUserAndSet())
            {
                ThrowException();
            }

            return user;

        }

        public int GetUserId()
        {
            if (userId == 0)
            {
                ThrowException();
            }
            return userId;
        }

        public int GetUserIdFromToken(ClaimsPrincipal claims)
        {
            SetToken(claims);
            return userId;
        }

        public void SetToken(ClaimsPrincipal claims)
        {
            if(claims.HasClaim(x => x.Type == "id"))
            {
                string id = claims.Claims.First(x => x.Type == "id").Value;
                FirstName = claims.Identity.Name;
                if (!int.TryParse(id, out userId))
                {
                    ThrowException();
                }
            }
            else
            {
                ThrowException();
            }
        }

        private bool CheckUserAndSet()
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            if(user == null)
            {
                return false;
            } else
            {
                this.user = user;
                return true;
            }
                
        }

        private void ThrowException()
        {
            throw new InvalidTokenException("access");
        }
    }
}
