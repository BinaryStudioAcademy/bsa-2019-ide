namespace BuildServer.Interfaces
{
    public interface IFileArchiver
    {
        void CreateArchive(string projectName);
        void UnZip(string projectName);
        void DeleteDirectory(string directoryName);
        void DeleteFile(string fileName);
    }
}
