using System;

namespace IDE.BLL.ExceptionsCustom
{
    public class InvalidAuthorException : Exception
    {
        public InvalidAuthorException() : base("Invalid project author")
        {

        }
    }
}
