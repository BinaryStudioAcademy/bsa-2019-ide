namespace IDE.Common.DTO.File
{
    public class FileCreateDTO
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public string Folder { get; set; }
        public int ProjectId { get; set; }
        
    }
}
