namespace IDE.DAL.Interfaces
{
    public interface IFileStorageNoSqlDbSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
