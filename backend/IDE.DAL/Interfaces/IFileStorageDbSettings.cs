namespace IDE.DAL.Interfaces
{
    public interface IFileStorageDbSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
