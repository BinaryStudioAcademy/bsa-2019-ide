using IDE.Common.DTO.User;

namespace IDE.Common.DTO.File
{
    public class FileUpdateDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public string Content { get; set; }
        public string Folder { get; set; }
        public bool IsOpen { get; set; }
        public int? UpdaterId { get; set; }
        public UserDTO Updater { get; set; }
    }
}
