using IDE.DAL.Interfaces;

namespace IDE.DAL.Settings
{
    public class FileStorageNoSqlDbSettings : IFileStorageNoSqlDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}