using AutoMapper;
using IDE.Common.DTO.Common;
using IDE.DAL.Entities;

namespace IDE.BLL.MappingProfiles
{
    public class ImageProfile: Profile
    {
        public ImageProfile()
        {
            CreateMap<Image, ImageDTO>();
            CreateMap<ImageDTO, Image>();
        }
    }
}
