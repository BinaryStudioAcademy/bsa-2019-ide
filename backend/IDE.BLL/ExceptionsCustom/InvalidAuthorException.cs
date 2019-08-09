using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.BLL.ExceptionsCustom
{
    class InvalidAuthorException : Exception
    {
        public InvalidAuthorException() : base("Invalid project author")
        {

        }
    }
}
