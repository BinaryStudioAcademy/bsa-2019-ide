using System;

namespace IDE.BLL.ExceptionsCustom
{
    public class InvalidUsernameOrPasswordException : Exception
    {
        public InvalidUsernameOrPasswordException(string message): base(message)
        {

        }
    }
}
