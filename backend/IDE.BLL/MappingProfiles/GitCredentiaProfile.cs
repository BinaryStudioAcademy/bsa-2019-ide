

using AutoMapper;
using IDE.Common.DTO.Common;
using IDE.DAL.Entities;

namespace IDE.BLL.MappingProfiles
{
    public class GitCredentiaProfile:Profile
    {
        public GitCredentiaProfile()
        {
            CreateMap<GitCredential, GitCredentialDTO>();
            CreateMap<GitCredentialDTO, GitCredential>();
        }
    }
}
