using IDE.DAL.Entities.NoSql.Abstract;
using System;

namespace IDE.DAL.Entities.NoSql
{
    public class FileHistory : BaseNoSqlModel
    {
        public string FileId { get; set; }
        public string ContentDiffHtml { get; set; }
        public DateTime ChangedAt { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int SizeDiff { get; set; }
        public int LinesIncreased { get; set; }
        public int LinesDecreased { get; set; }
        public string ChangingAction { get; set; }
    }
}