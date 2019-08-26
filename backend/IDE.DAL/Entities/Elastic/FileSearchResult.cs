using IDE.DAL.Entities.Elastic.Abstract;
using Nest;

namespace IDE.DAL.Entities.Elastic
{
    public class FileSearchResult
    {
        public FileSearch FileSearch { get; set; }
        public string Hightlight { get; set; }
    }
}
