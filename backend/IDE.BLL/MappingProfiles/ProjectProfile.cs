using AutoMapper;
using IDE.Common.DTO.Common;
using IDE.DAL.Entities;

namespace IDE.BLL.MappingProfiles
{
    public class ProjectProfile: Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDTO>();
            CreateMap<ProjectDTO, Project>();
        }
    }
}
