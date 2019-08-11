using AutoMapper;
using IDE.Common.DTO.Common;
using IDE.DAL.Entities;

namespace IDE.BLL.MappingProfiles
{
    public class BuildProfile: Profile
    {
        public BuildProfile()
        {
            CreateMap<Build, BuildDTO>();
            CreateMap<BuildDTO, Build>();
        }
    }
}
