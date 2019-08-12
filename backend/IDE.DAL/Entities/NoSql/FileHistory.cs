using IDE.DAL.Entities.NoSql.Abstract;
using System;

namespace IDE.DAL.Entities.NoSql
{
    public class FileHistory : BaseNoSqlModel
    {
        public string FileId { get; set; }

        public string Name { get; set; }
        public string Content { get; set; }
        public string Folder { get; set; }

        public DateTime CreatedAt { get; set; }
        public int CreatorId { get; set; }
    }
}
