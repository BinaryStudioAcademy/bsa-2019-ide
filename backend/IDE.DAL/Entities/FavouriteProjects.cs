using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.DAL.Entities
{
    public class FavouriteProjects
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
