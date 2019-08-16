using IDE.DAL.Entities;
using System.Security.Claims;

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
