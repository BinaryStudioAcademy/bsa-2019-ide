namespace IDE.DAL.Interfaces
{
    public interface IFileStorageDbSettings
    {
        string FilesCollectionName { get; set; }
        string FileHistoriesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
