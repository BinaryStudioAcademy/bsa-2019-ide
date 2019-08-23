using IDE.Common.DTO.User;
using System.Threading.Tasks;

namespace IDE.BLL.Interfaces
{
    public interface ISocialAuthService
    {
        Task<AuthUserDTO> LogInAsync(SocialAuthUserDetailsDTO socialAuthUserDetailsDTO);
    }
}
