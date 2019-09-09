using System;

namespace IDE.Common.DTO.File
{
    public class FileHistoryDTO
    {
        public string Id { get; set; }
        public string FileId { get; set; }
        public string ContentDiffHtml { get; set; }
        public DateTime ChangedAt { get; set; }
        public int AuthorId { get; set; }
        public int AuthorName { get; set; }
        public int SizeDiff { get; set; }
        public int LinesIncreased { get; set; }
        public int LinesDecreased { get; set; }
    }
}
