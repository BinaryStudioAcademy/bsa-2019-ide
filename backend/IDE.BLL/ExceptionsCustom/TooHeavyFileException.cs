using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.BLL.ExceptionsCustom
{
    public class TooHeavyFileException : Exception
    {
        public TooHeavyFileException(int fileSize) : base("Your file size is too big. Maximum file size is " + fileSize  / 1024 + "Kb") { }
    }
}
