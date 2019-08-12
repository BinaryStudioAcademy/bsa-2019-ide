using IDE.DAL.Entities.NoSql.Abstract;
using System;

namespace IDE.DAL.Entities.NoSql
{
    public class File : BaseNoSqlModel
    {
        public string Name { get; set; }
        public string Folder { get; set; }
        public string Content { get; set; }
        public int ProjectId { get; set; }

        public DateTime CreatedAt { get; set; }
        public int CreatorId { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public int? UpdaterId { get; set; }
    }
}
