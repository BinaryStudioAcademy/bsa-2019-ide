using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.BLL.ExceptionsCustom
{
    class RightsChangeForProjectAuthorException : Exception
    {
        public RightsChangeForProjectAuthorException() : base("You try to change project author rights!")
        {

        }
    }
}
