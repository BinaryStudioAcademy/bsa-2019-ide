using IDE.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.DAL.Entities
{
    public class ProjectMembers
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public UserAccesses UserAcces { get; set; }
    }
}
