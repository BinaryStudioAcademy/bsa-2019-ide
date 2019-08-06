using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.BLL.ExceptionsCustom
{
    class InvalidUsernameOrPasswordException : Exception
    {
        public InvalidUsernameOrPasswordException(string message): base(message)
        {

        }
    }
}
