using AutoMapper;
using IDE.BLL.Interfaces;
using IDE.Common.DTO.User;
using IDE.Common.Enums;
using IDE.DAL.Context;
using IDE.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace IDE.BLL.Services
{
    public class SocialAuthService : ISocialAuthService
    {
        private readonly IdeContext _context;
        private readonly IMapper _mapper;
        private readonly AuthService _authService;

        public SocialAuthService(IdeContext context, IMapper mapper, AuthService authService)
        {
            _context = context;
            _mapper = mapper;
            _authService = authService;
        }

        public async Task<AuthUserDTO> LogInAsync(SocialAuthUserDetailsDTO socialAuthDTO)
        {
            User userEntity;
            var existingSocialAuthAccount = _context.SocialAuthAccounts
                .Include(sa => sa.User)
                .FirstOrDefault(sa => sa.AccountId == socialAuthDTO.AccountId);
            if (existingSocialAuthAccount != null)
            {
                userEntity = existingSocialAuthAccount.User;
            }
            else
            {
                if (string.IsNullOrEmpty(socialAuthDTO.FirstName) 
                    && string.IsNullOrEmpty(socialAuthDTO.LastName) 
                    && !string.IsNullOrEmpty(socialAuthDTO.FullName))
                {
                    var nameParts = socialAuthDTO.FullName.Split(' ');
                    socialAuthDTO.FirstName = nameParts[0];
                    socialAuthDTO.LastName = nameParts[1];
                }

                userEntity = new User
                {
                    FirstName = socialAuthDTO.FirstName,
                    LastName = socialAuthDTO.LastName,
                    NickName = socialAuthDTO.NickName,
                    Email = socialAuthDTO.Email,
                    GitHubUrl = socialAuthDTO.Provider == SocialProvider.GitHub
                        ? $"github.com/{socialAuthDTO.NickName}" : null,
                    Avatar = new Image { Url = socialAuthDTO.Picture }
                };

                _context.Users.Add(userEntity);
                await _context.SaveChangesAsync();

                var createdSocialAuthAccount = new SocialAuthAccount
                {
                    AccountId = socialAuthDTO.AccountId,
                    Provider = socialAuthDTO.Provider,
                    UserId = userEntity.Id
                };

                _context.SocialAuthAccounts.Add(createdSocialAuthAccount);
                await _context.SaveChangesAsync();
            }

            var token = await _authService.GenerateAccessToken(userEntity);
            var user = _mapper.Map<UserDTO>(userEntity);

            return new AuthUserDTO
            {
                User = user,
                Token = token
            };
        }
    }
}
