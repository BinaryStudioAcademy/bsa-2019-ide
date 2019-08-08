using IDE.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.Common.DTO.Common
{
    public class GitCredentialDTO
    {
        public GitProvider Provider { get; set; }
        public string Url { get; set; }
        public string Login { get; set; }
    }
}
