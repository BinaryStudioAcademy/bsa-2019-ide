using System.Collections.Generic;

namespace IDE.Common.ModelsDTO.DTO.File
{
    public class FileGlobalSearchResultDTO
    {
        public string FileId { get; set; }
        public string FileName { get; set; }
        public string Content { get; set; }
        public int ProjectId { get; set; }
    }
}
