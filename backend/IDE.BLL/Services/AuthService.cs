using AutoMapper;
using IDE.BLL.JWT;
using IDE.Common;
using IDE.Common.DTO.Authentification;
using IDE.Common.DTO.User;
using IDE.DAL.Entities;
using IDE.Common.Security;
using IDE.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDE.BLL.ExceptionsCustom;

namespace IDE.BLL.Services
{
    public class AuthService
    {
        private readonly BaseContext _context;
        private readonly JWTFactory _jwtFactory;
        private readonly IMapper _mapper;

        public AuthService(BaseContext context, IMapper mapper, JWTFactory jwtFactory)// : base(context, mapper)
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
                throw new Exception("Such user doesn't exist");//NotFoundException(nameof(User));
            }

            if (!SecurityHelper.ValidatePassword(userDto.Password, userEntity.Password, userEntity.Salt))
            {
                throw new Exception("Incorrect password or username");//InvalidUsernameOrPasswordException();
            }

            var token = await GenerateAccessToken(userEntity.Id, userEntity.UserName, userEntity.Email);
            var user = _mapper.Map<UserDTO>(userEntity);

            return new AuthUserDTO
            {
                User = user,
                Token = token
            };
        }

        public async Task<AccessTokenDTO> GenerateAccessToken(int userId, string userName, string email)
        {
            var refreshToken = _jwtFactory.GenerateRefreshToken();

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
                throw new Exception("While getting a token such user doesn't exist"); //NotFoundException(nameof(BaseUser), userId);
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

            var jwtToken = await _jwtFactory.GenerateAccessToken(userEntity.Id, userEntity.UserName, userEntity.Email); //generate access token
            var refreshToken = _jwtFactory.GenerateRefreshToken(); //generate random token 

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
