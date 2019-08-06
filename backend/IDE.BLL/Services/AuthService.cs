using AutoMapper;
using IDE.BLL.JWT;
using IDE.Common.DTO.Authentification;
using IDE.Common.DTO.User;
using IDE.DAL.Entities;
using IDE.Common.Security;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using IDE.BLL.ExceptionsCustom;
using IDE.DAL.Context;
using IDE.BLL.Helpers;

namespace IDE.BLL.Services
{
    public class AuthService
    {
        private protected readonly IdeContext _context;
        private readonly JWTFactory _jwtFactory;
        private readonly IMapper _mapper;

        public AuthService(IdeContext context, IMapper mapper, JWTFactory jwtFactory)
        {
            _context = context;
            _jwtFactory = jwtFactory;
            _mapper = mapper;
        }

        public async Task<AuthUserDTO> Authorize(UserLoginDTO userDto)
        {
            var userEntity = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == userDto.Email);

            if (userEntity == null)
            {
                throw new NotFoundException(name: nameof(userEntity));
            }

            if (!SecurityHelper.ValidatePassword(userDto.Password, userEntity.PasswordHash, userEntity.PasswordSalt))
            {
                throw new InvalidUsernameOrPasswordException("wrong passwork or username");
            }

            var token = await GenerateAccessToken(userEntity.Id, userEntity.GetUserName(), userEntity.Email);
            var user = _mapper.Map<UserDTO>(userEntity);

            return new AuthUserDTO
            {
                User = user,
                Token = token
            };
        }

        public async Task<AccessTokenDTO> GenerateAccessToken(int userId, string userName, string email)
        {
            var refreshToken = JWTFactory.GenerateRefreshToken();

            _context.RefreshTokens.Add(new RefreshToken
            {
                Token = refreshToken,
                UserId = userId
            });

            await _context.SaveChangesAsync();

            var accessToken = await _jwtFactory.GenerateAccessToken(userId, userName, email);

            return new AccessTokenDTO(accessToken, refreshToken);
        }

        public async Task<AccessTokenDTO> RefreshToken(RefreshTokenDTO dto)
        {
            var userId = _jwtFactory.GetUserIdFromToken(dto.AccessToken, dto.Key); //get userId from our access token
            var userEntity = await _context.Users.FindAsync(userId); //find user with such id

            if (userEntity == null) 
            {
                throw new NotFoundException(nameof(userEntity)); 
            }

            var rToken = await _context.RefreshTokens.FirstOrDefaultAsync(t => t.Token == dto.RefreshToken && t.UserId == userId); // find such token for user

            if (rToken == null)
            {
                throw new InvalidTokenException("refresh");
            }

            if (!rToken.IsActive)
            {
                throw new ExpiredRefreshTokenException();
            }

            var jwtToken = await _jwtFactory.GenerateAccessToken(userEntity.Id, userEntity.GetUserName(), userEntity.Email); //generate access token
            var refreshToken = JWTFactory.GenerateRefreshToken(); //generate random token 

            _context.RefreshTokens.Remove(rToken); // remove previous one
            _context.RefreshTokens.Add(new RefreshToken //create new token
            {
                Token = refreshToken,
                UserId = userEntity.Id
            });

            await _context.SaveChangesAsync();

            return new AccessTokenDTO(jwtToken, refreshToken); //send to front generated tokens
        }

        public async Task RevokeRefreshToken(string refreshToken, int userId)
        {
            var rToken = _context.RefreshTokens.FirstOrDefault(t => t.Token == refreshToken && t.UserId == userId); //find token

            if (rToken == null)
            {
                throw new InvalidTokenException("refresh");
            }

            _context.RefreshTokens.Remove(rToken); //remove it
            await _context.SaveChangesAsync();
        }
    }
}
