using System.Collections.Generic;

namespace IDE.DAL.Entities.Elastic
{
    public class FileSearchResult
    {
        public string FileId { get; set; }
        public string FileName { get; set; }
        public IReadOnlyDictionary<string, IReadOnlyCollection<string>> Hightlights { get; set; }
    }
}
