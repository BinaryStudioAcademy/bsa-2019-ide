using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.DAL.Entities
{
    public class FavouriteProjects
    {
        public int Project { get; set; }
        public int ProjectId { get; set; }

        public int User { get; set; }
        public int UserId { get; set; }
    }
}
