using AutoMapper;
using IDE.Common.DTO.Common;
using IDE.Common.ModelsDTO.DTO.Common;
using IDE.DAL.Entities;

namespace IDE.BLL.MappingProfiles
{
    public class BuildProfile: Profile
    {
        public BuildProfile()
        {
            CreateMap<Build, BuildDTO>();
            CreateMap<BuildDTO, Build>();

            CreateMap<Build, BuildDescriptionDTO>()
                .ForMember(x => x.UserName, y => y.MapFrom(z => z.User.NickName))
                .ForMember(x => x.ProjectName, y => y.MapFrom(z => z.Project.Name));
        }
    }
}
