using AutoMapper;
using IDE.Common.DTO.Common;
using IDE.Common.DTO.Project;
using IDE.Common.ModelsDTO.DTO.Project;
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

            CreateMap<Project, ProjectInfoDTO>()
                .ForMember(x => x.AuthorName, y => y.MapFrom(z => z.Author.NickName));

            CreateMap<Project, ProjectUserPageDTO>();

            CreateMap<Project, ProjectDescriptionDTO>()
                .ForMember(x => x.Created, y => y.MapFrom(z => z.CreatedAt))
                .ForMember(x => x.Title, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Creator, y => y.MapFrom(z => z.Author.NickName))
                .ForMember(x => x.CreatorId, y => y.MapFrom(z => z.AuthorId));
        }
    }
}
