using IDE.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.Common.ModelsDTO.DTO.Git
{
    public class GitCredentialsDTO
    {
        public GitProvider Provider { get; set; }
        public string Url { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string ProjectId { get; set; }
    }
}
