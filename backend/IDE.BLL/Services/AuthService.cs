using AutoMapper;
using IDE.BLL.ExceptionsCustom;
using IDE.BLL.JWT;
using IDE.Common.DTO.User;
using IDE.Common.ModelsDTO.DTO.Authentification;
using IDE.Common.ModelsDTO.Enums;
using IDE.Common.Security;
using IDE.DAL.Context;
using IDE.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace IDE.BLL.Services
{
    public class AuthService
    {
        private readonly IdeContext _context;
        private readonly JWTFactory _jwtFactory;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthService> _logger;
        public AuthService(IdeContext context, IMapper mapper, JWTFactory jwtFactory, ILogger<AuthService> logger)
        {
            _context = context;
            _jwtFactory = jwtFactory;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<AuthUserDTO> Authorize(UserLoginDTO userDto)
        {
            var userEntity = await _context.Users
                .Include(x => x.Avatar)
                .FirstOrDefaultAsync(u => u.Email == userDto.Email);

            if (userEntity == null)
            {
                _logger.LogWarning(LoggingEvents.HaveException, $"Not found user");
                throw new NotFoundException(name: nameof(userEntity));
            }

            

            if (!SecurityHelper.ValidatePassword(userDto.Password, userEntity.PasswordHash, userEntity.PasswordSalt))
            {
                _logger.LogWarning(LoggingEvents.HaveException, $"invalid username or password");
                throw new InvalidUsernameOrPasswordException("wrong username or password");
            }

            var token = await GenerateAccessToken(userEntity);
            var user = _mapper.Map<UserDTO>(userEntity);

            return new AuthUserDTO
            {
                User = user,
                Token = token
            };
        }

        public async Task<AccessTokenDTO> GenerateAccessToken(User user)
        {
            var refreshToken = JWTFactory.GenerateRefreshToken();

            _context.RefreshTokens.Add(new RefreshToken
            {
                Token = refreshToken,
                UserId = user.Id
            });

            await _context.SaveChangesAsync();

            var accessToken = await _jwtFactory.GenerateAccessToken(user);

            return new AccessTokenDTO(accessToken, refreshToken);
        }

        public async Task<AccessTokenDTO> RefreshToken(RefreshTokenDTO dto)
        {
            var userId = _jwtFactory.GetUserIdFromToken(dto.AccessToken, dto.Key); //get userId from our access token
            var userEntity = _context.Users
                            .Include(u => u.Avatar)
                            .FirstOrDefault(x => x.Id == userId); //find user with such id

            if (userEntity == null) 
            {
                _logger.LogWarning(LoggingEvents.HaveException, $"Not found user");
                throw new NotFoundException(nameof(userEntity)); 
            }

            var rToken = await _context.RefreshTokens.FirstOrDefaultAsync(t => t.Token == dto.RefreshToken && t.UserId == userId); // find such token for user

            if (rToken == null)
            {
                _logger.LogWarning(LoggingEvents.HaveException, $"invalid token");
                throw new InvalidTokenException("refresh");
            }

            if (!rToken.IsActive)
            {
                _logger.LogWarning(LoggingEvents.HaveException, $"expired refresh token");
                throw new ExpiredRefreshTokenException();
            }

            var jwtToken = await _jwtFactory.GenerateAccessToken(userEntity); //generate access token
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
                _logger.LogWarning(LoggingEvents.HaveException, $"invalid token");
                throw new InvalidTokenException("refresh");
            }

            _context.RefreshTokens.Remove(rToken); //remove it
            await _context.SaveChangesAsync();
        }
    }
}
