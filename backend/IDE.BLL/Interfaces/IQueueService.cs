namespace IDE.BLL.Interfaces
{
    public interface IQueueService
    {
        bool SendMessage(string message);
    }
}
