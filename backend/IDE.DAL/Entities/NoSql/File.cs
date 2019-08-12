using IDE.DAL.Entities.NoSql.Abstract;
using System;

namespace IDE.DAL.Entities.NoSql
{
    public class File : BaseNoSqlModel
    {
        public string Name { get; set; }
        public string Folder { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ProjectId { get; set; }

        public int CreatorId { get; set; }
        // public User Creator { get; set; } // need only for DTO

        public int? UpdaterId { get; set; }
        // public User Updater { get; set; } // need only for DTO

        public string LastFileHistoryId { get; set; }
        // public FileHistory LastFileHistory { get; set; } // need only for DTO
    }
}
