using AutoMapper;
using IDE.Common.ModelsDTO.DTO.Workspace;
using IDE.DAL.Entities.NoSql;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.BLL.MappingProfiles
{

    public class ProjectStructureProfile : Profile
    {
        public ProjectStructureProfile()
        {
            CreateMap<FileStructure, FileStructureDTO>();
            CreateMap<FileStructureDTO, FileStructure>();
            CreateMap<ProjectStructureDTO, ProjectStructure>()
                .ForMember(a => a.NestedFiles, b => b.UseDestinationValue());
            CreateMap<ProjectStructure, ProjectStructureDTO>();
        }
    }
}
