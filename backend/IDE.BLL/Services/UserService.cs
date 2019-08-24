using AutoMapper;
using IDE.BLL.ExceptionsCustom;
using IDE.BLL.Interfaces;
using IDE.Common.DTO.User;
using IDE.Common.ModelsDTO.DTO.User;
using IDE.Common.Security;
using IDE.DAL.Context;
using IDE.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDE.BLL.Helpers;
using IDE.Common.DTO.Image;

namespace IDE.BLL.Services
{
    public class UserService
    {
        private readonly IMapper _mapper;
        private readonly IdeContext _context;
        private readonly IEmailService _emailService;
        private readonly IImageUploader _imageUploader;

        public UserService(IdeContext context, IEmailService emailService, IMapper mapper, IImageUploader imageUploader)
        {
            _mapper = mapper;
            _context = context;
            _emailService = emailService;
            _imageUploader = imageUploader;
        }

        public async Task<User> CreateUser(UserRegisterDTO userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            var user = await _context.Users.Where(a => a.Email == userEntity.Email).FirstOrDefaultAsync();
            if (user != null)
            {
                throw new ExistedUserLoginException();
            }

            var salt = SecurityHelper.GetRandomBytes();

            userEntity.PasswordSalt = Convert.ToBase64String(salt);
            userEntity.PasswordHash = SecurityHelper.HashPassword(userDto.Password, salt);
            userEntity.RegisteredAt = DateTime.Now;

            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();
            await SendConfirmationMail(userEntity.Id);
            return userEntity;
        }

        public async Task<UserNicknameDTO[]> GetUserListByNickNameParts(int currentUser)
        {

            return await _context.Users
                .Where(item=>item.Id!=currentUser)
                .Select(u => new UserNicknameDTO()
                    {
                        Id = u.Id,
                        NickName = u.NickName
                    }).ToArrayAsync();

        }

        public async Task<UserDTO> UpdateUser(UserUpdateDTO userUpdateDto)
        {
            var targetUser = await _context.Users.SingleOrDefaultAsync(p => p.Id == userUpdateDto.Id);

            if (targetUser == null)
            {
                throw new NotFoundException(nameof(targetUser), targetUser.Id);
            }

            targetUser.FirstName = userUpdateDto.FirstName;
            targetUser.LastName = userUpdateDto.LastName;
            targetUser.NickName = userUpdateDto.NickName;
            targetUser.GitHubUrl = userUpdateDto.GitHubUrl;

            _context.Users.Update(targetUser);
            await _context.SaveChangesAsync();

            return await GetUserById(targetUser.Id);
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

        public async Task SendConfirmationMail(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                throw new NotFoundException("user", userId);
            }
            if (user.EmailConfirmed)
            {
                throw new EmailConfirmedException();
            }
            string token = GenerateSymbols.GenerateRandomSymbols();
            var verificationToken = new VerificationToken()
            {
                Token = token,
                UserId = userId
            };
            _context.VerificationTokens.Add(verificationToken);
            await _context.SaveChangesAsync();

            await _emailService.SendEmailVerificationMail(user.Email, token);
        }

        public async Task VerifyEmail(string token)
        {
            var verToken = _context.VerificationTokens
                .FirstOrDefault(t => t.Token == token);
            if (verToken == null)
            {
                throw new NotFoundException("Such token");
            }
            var userTokens = _context.VerificationTokens.Where(u => u.UserId == verToken.UserId);
            _context.VerificationTokens.RemoveRange(userTokens);

            var user = _context.Users.FirstOrDefault(u => u.Id == verToken.Id);
            if(user != null)
            {
                user.EmailConfirmed = true;
                _context.Users.Update(user);
            }
            await _context.SaveChangesAsync();
        }

        public async Task RecoverPassword(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                throw new NotFoundException("User with such email was");
            }

            var salt = SecurityHelper.GetRandomBytes();
            var password = GenerateSymbols.GenerateRandomSymbols(9);

            user.PasswordSalt = Convert.ToBase64String(salt);
            user.PasswordHash = SecurityHelper.HashPassword(password, salt);
            _context.Users.Update(user);

            await _emailService.SendPasswordRecoveryMail(email, password);
            await _context.SaveChangesAsync();
        }

        private async Task<User> GetUserByIdInternal(int id)
        {
            return await _context.Users
                .Include(u => u.Avatar)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateUserAvatar(ImageUploadBase64DTO imageUploadBase64DTO, int userId)
        {
            var imgSrc = await _imageUploader.UploadAsync(imageUploadBase64DTO.Base64);
            var targetUser = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);

            await _context.Images.AddAsync(new Image { Url = imgSrc });
            await _context.SaveChangesAsync();

            var imageId = await _context.Images.LastAsync();

            targetUser.AvatarId = imageId.Id;

            _context.Users.Update(targetUser);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAvatar(int userId)
        {
            var targetUser = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);
            var tarhetImage = await _context.Images.SingleOrDefaultAsync(i => i.Id == targetUser.AvatarId);

            targetUser.AvatarId = null;
            _context.Images.Remove(tarhetImage);

            await _context.SaveChangesAsync();
        }
    }
}
