namespace IDE.BLL.Interfaces
{
    public interface IQueueService
    {
        bool SendBuildMessage(string message);
        bool SendRunMessage(string value);
    }
}
