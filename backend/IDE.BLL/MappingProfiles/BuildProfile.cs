using AutoMapper;
using IDE.Common.DTO.Common;
using IDE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
