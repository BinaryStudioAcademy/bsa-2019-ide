using System.Collections.Generic;

namespace IDE.Common.ModelsDTO.DTO.File
{
    public class FileSearchResultDTO
    {
        public string FileId { get; set; }
        public string FileName { get; set; }
        public IReadOnlyDictionary<string, IReadOnlyCollection<string>> Hightlights { get; set; }
        public int? ProjectId { get; set; }
    }
}
