namespace IDE.BLL.Interfaces
{
    //Basic wrapper for queue. 
    public interface IQueueService
    {
        bool SendMessage(string value);
    }
}
