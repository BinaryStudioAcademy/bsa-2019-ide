using AutoMapper;
using IDE.Common.DTO.User;
using IDE.Common.ModelsDTO.DTO.Common;
using IDE.Common.ModelsDTO.DTO.User;
using IDE.DAL.Entities;

namespace IDE.BLL.MappingProfiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDetailsDTO>()
                .ForMember("Url", opt => opt.MapFrom(u => u.Avatar.Url));
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<UserRegisterDTO, User>();
            CreateMap<User, UserRegisterDTO>();

            CreateMap<EditorSetting, EditorSettingDTO>();
            CreateMap<EditorSettingDTO, EditorSetting>();

            CreateMap<User, UserUpdateDTO>();
            CreateMap<UserUpdateDTO, User>();
        }
    }
}
