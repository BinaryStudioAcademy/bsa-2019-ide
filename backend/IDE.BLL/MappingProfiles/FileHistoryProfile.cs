using AutoMapper;
using IDE.Common.ModelsDTO.DTO.File;
using IDE.DAL.Entities.NoSql;

namespace IDE.BLL.MappingProfiles
{
    public class FileHistoryProfile : Profile
    {
        public FileHistoryProfile()
        {
            CreateMap<FileHistory, FileHistoryDTO>();
            CreateMap<FileHistoryDTO, FileHistory>();
            CreateMap<FileHistory, FileHistoryDiffContentDTO>();
        }
    }
}
