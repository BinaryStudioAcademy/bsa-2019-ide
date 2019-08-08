using AutoMapper;
using IDE.Common.DTO.Common;
using IDE.Common.DTO.Project;
using IDE.DAL.Entities;

namespace IDE.BLL.MappingProfiles
{
    public class ProjectProfile: Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDTO>();
            CreateMap<ProjectDTO, Project>();

            CreateMap<ProjectCreateDTO, Project>();

            CreateMap<Project, ProjectDescriptionDTO>()
                .ForMember(x => x.Created, y => y.MapFrom(z => z.CreatedAt))
                .ForMember(x => x.Title, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Creator, y => y.MapFrom(z => z.Author.Id))
                .ForMember(x => x.PhotoLink, y => y.MapFrom(z => z.Logo.Url));
        }
    }
}
