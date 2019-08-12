using IDE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace IDE.BLL.Interfaces
{
    public interface ITokenService
    {
        string FirstName { get; }
        User GetUser();
        int GetUserId();
        int GetUserIdFromToken(ClaimsPrincipal claims);
        void SetToken(ClaimsPrincipal claims);
    }
}
