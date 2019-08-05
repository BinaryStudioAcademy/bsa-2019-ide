using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.DAL.Entities
{
    public class ProjectMembers
    {
        int Id { get; set; }
        int ProjectId { get; set; }
        int UserId { get; set; }
        UserAccesses UserAcces { get; set; }
    }
}
