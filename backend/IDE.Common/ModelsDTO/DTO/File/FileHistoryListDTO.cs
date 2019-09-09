using System.Collections.Generic;

namespace IDE.Common.ModelsDTO.DTO.File
{
    public class FileHistoryListDTO
    {
        public FileHistoryListDTO()
        {
            History = new List<FileHistoryDTO>();
        }
        public string Id { get; set; }
        public string FileName { get; set; }
        public IList<FileHistoryDTO> History { get; set; }
    }
}
