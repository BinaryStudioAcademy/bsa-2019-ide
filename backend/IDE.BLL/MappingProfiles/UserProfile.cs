using AutoMapper;
using IDE.Common.DTO.User;
using IDE.DAL.Entities;

namespace IDE.BLL.MappingProfiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<UserRegisterDTO, User>();
            CreateMap<User, UserRegisterDTO>();

        }
    }
}
