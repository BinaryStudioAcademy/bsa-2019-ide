using IDE.Common.Enums;

namespace IDE.Common.DTO.Common
{
    public class GitCredentialDTO
    {
        public GitProvider Provider { get; set; }
        public string Url { get; set; }
        public string Login { get; set; }
    }
}
