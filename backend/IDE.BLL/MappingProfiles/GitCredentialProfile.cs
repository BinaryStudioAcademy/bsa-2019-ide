

using AutoMapper;
using IDE.Common.DTO.Common;
using IDE.DAL.Entities;

namespace IDE.BLL.MappingProfiles
{
    public class GitCredentialProfile:Profile
    {
        public GitCredentialProfile()
        {
            CreateMap<GitCredential, GitCredentialDTO>();
            CreateMap<GitCredentialDTO, GitCredential>();
        }
    }
}
