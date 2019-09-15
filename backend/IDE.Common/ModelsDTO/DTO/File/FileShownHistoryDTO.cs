using System;

namespace IDE.Common.ModelsDTO.DTO.File
{
    public class FileShownHistoryDTO
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public string Content { get; set; }
        public string CreatorNickname { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
