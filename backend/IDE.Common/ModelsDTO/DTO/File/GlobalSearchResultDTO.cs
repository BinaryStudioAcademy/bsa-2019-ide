using System.Collections.Generic;

namespace IDE.Common.ModelsDTO.DTO.File
{
    public class GlobalSearchResultDTO
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public List<FileGlobalSearchResultDTO> FoundFiles { get; set; }
    }
}
