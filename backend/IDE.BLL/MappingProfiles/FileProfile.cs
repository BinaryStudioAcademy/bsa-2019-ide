using AutoMapper;
using IDE.Common.DTO.File;
using IDE.DAL.Entities.Elastic;
using IDE.DAL.Entities.NoSql;

namespace IDE.BLL.MappingProfiles
{
    public class FileProfile : Profile
    {
        public FileProfile()
        {
            CreateMap<File, FileDTO>();
            CreateMap<FileDTO, File>();
            CreateMap<FileCreateDTO, File>();
            CreateMap<FileUpdateDTO, File>();
            CreateMap<File, FileSearch>();
            CreateMap<FileDTO, FileUpdateDTO>();
        }
    }
}
