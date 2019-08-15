using AutoMapper;
using IDE.BLL.ExceptionsCustom;
using IDE.Common.DTO.User;
using IDE.Common.Security;
using IDE.DAL.Context;
using IDE.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IDE.BLL.Services
{
    public class UserService
    {
        private readonly IdeContext _context;
        private readonly IMapper _mapper;
        public UserService(IdeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> CreateUser(UserRegisterDTO userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            var user = await _context.Users.Where(a => a.Email == userEntity.Email).FirstOrDefaultAsync();
            if(user!=null)
            {
                throw new ExistedUserLoginException();
            }

            var salt = SecurityHelper.GetRandomBytes();

            userEntity.PasswordSalt = Convert.ToBase64String(salt);
            userEntity.PasswordHash = SecurityHelper.HashPassword(userDto.Password, salt);
            userEntity.RegisteredAt = DateTime.Now;

            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();

            return userEntity;
        }

        public async Task<UserDetailsDTO> GetUserDetailsById(int id)
        {
            var user = await GetUserByIdInternal(id);
            if (user == null)
            {
                throw new NotFoundException(nameof(User), id);
            }

            return _mapper.Map<UserDetailsDTO>(user);
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            var user = await GetUserByIdInternal(id);
            if (user == null)
            {
                throw new NotFoundException(nameof(User), id);
            }

            return _mapper.Map<UserDTO>(user);
        }

        private async Task<User> GetUserByIdInternal(int id)
        {
            return await _context.Users
                .Include(u => u.Avatar)
                .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
