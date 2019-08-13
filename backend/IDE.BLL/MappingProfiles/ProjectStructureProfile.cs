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
            CreateMap<FileStructure, FileDTO>();
            CreateMap<FileDTO, FileStructure>();
            CreateMap<ProjectStructureDTO, ProjectStructure>();
            CreateMap<ProjectStructure, ProjectStructureDTO>();
        }
    }
}
