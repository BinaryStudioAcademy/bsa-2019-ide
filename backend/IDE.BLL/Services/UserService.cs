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
using Microsoft.Extensions.Logging;
using IDE.Common.ModelsDTO.Enums;

namespace IDE.BLL.Services
{
    public class UserService
    {
        private readonly IdeContext _context;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<UserService> _logger;
        private readonly IEditorSettingService _editorSettingService;
        public UserService(IdeContext context, 
            IEmailService emailService, 
            IMapper mapper, 
            ILogger<UserService> logger,
            IEditorSettingService editorSettingService)
        {
            _context = context;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
            _editorSettingService = editorSettingService;
        }

        public async Task<User> CreateUser(UserRegisterDTO userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            var user = await _context.Users.Where(a => a.Email == userEntity.Email).FirstOrDefaultAsync();
            if (user != null)
            {
                _logger.LogWarning(LoggingEvents.HaveException, $"user already exists");
                throw new ExistedUserLoginException();
            }

            var salt = SecurityHelper.GetRandomBytes();

            userEntity.PasswordSalt = Convert.ToBase64String(salt);
            userEntity.PasswordHash = SecurityHelper.HashPassword(userDto.Password, salt);
            userEntity.RegisteredAt = DateTime.Now;
            userEntity.EditorSettingsId = await _editorSettingService.CreateInitEditorSettings();

            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();
            await SendConfirmationMail(userEntity.Id);
            return userEntity;
        }

        public async Task<UserDTO> Update(UserDetailsDTO userDTO)
        {
            var targetUser = await GetUserByIdInternal(userDTO.Id);

            if (targetUser == null)
            {
                _logger.LogWarning(LoggingEvents.HaveException, $"update user not found");
                throw new NotFoundException(nameof(targetUser), userDTO.Id);
            }
             
            if(targetUser.EditorSettings==null)
            {
                targetUser.EditorSettingsId = (await _editorSettingService.CreateEditorSettings(userDTO.EditorSettings)).Id;
            }

            _context.Users.Update(targetUser);
            await _context.SaveChangesAsync();

            return await GetUserById(userDTO.Id);
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

        public async Task<UserDetailsDTO> GetUserDetailsById(int id)
        {
            var user = await GetUserByIdInternal(id);
            if (user == null)
            {
                _logger.LogWarning(LoggingEvents.HaveException, $"user not found");
                throw new NotFoundException(nameof(User), id);
            }

            return _mapper.Map<UserDetailsDTO>(user);
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            var user = await GetUserByIdInternal(id);
            if (user == null)
            {
                _logger.LogWarning(LoggingEvents.HaveException, $"user not found");
                throw new NotFoundException(nameof(User), id);
            }

            return _mapper.Map<UserDTO>(user);
        }

        public async Task SendConfirmationMail(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                _logger.LogWarning(LoggingEvents.HaveException, $"not found user");
                throw new NotFoundException("user", userId);
            }
            if (user.EmailConfirmed)
            {
                _logger.LogWarning(LoggingEvents.HaveException, $"email confirmed exception");
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
                _logger.LogWarning(LoggingEvents.HaveException, $"not found verification token");
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
                _logger.LogWarning(LoggingEvents.HaveException, $"not user with such email");
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
                .Include(i=>i.EditorSettings)
                .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
