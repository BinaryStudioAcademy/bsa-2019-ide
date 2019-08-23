
namespace IDE.Common.ModelsDTO.Enums
{
    public class LoggingEvents
    {
        public const int GenerateItems = 1000;
        public const int ListItems = 1001;
        public const int GetItem = 1002;
        public const int InsertItem = 1003;
        public const int UpdateItem = 1004;
        public const int DeleteItem = 1005;

        public const int GetItemNotFound = 4000;
        public const int UpdateItemNotFound = 4001;
        public const int DeleteItemNotFound = 4002;
        public const int HaveException = 5000;
        public const int CheckInfo = 6000;
    }
}
