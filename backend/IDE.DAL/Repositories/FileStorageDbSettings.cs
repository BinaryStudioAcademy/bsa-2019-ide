using IDE.DAL.Interfaces;

namespace IDE.DAL.Repositories
{
    public class FileStorageDbSettings : IFileStorageDbSettings
    {
        public string FilesCollectionName { get; set; }
        public string FileHistoriesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}