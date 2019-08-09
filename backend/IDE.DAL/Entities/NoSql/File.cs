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

        public int FileHistoryId { get; set; }
        public FileHistory FileHistory { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
