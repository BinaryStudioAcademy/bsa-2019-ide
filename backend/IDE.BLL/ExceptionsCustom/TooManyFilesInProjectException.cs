using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.BLL.ExceptionsCustom
{
    public class TooManyFilesInProjectException : Exception
    {
        public TooManyFilesInProjectException(int maxFilesCount): base("There are too many files in this project, maximum amount - " + maxFilesCount) { }
    }
}
