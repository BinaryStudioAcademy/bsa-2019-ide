using AutoMapper;
using IDE.Common.DTO.User;
using IDE.DAL.Entities;

namespace IDE.BLL.MappingProfiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember("Url", opt => opt.MapFrom(u => u.Avatar.Url));
            CreateMap<UserDTO, User>();

            CreateMap<UserRegisterDTO, User>();
            CreateMap<User, UserRegisterDTO>();

        }
    }
}
