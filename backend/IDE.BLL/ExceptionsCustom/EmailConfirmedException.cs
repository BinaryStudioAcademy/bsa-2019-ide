using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.BLL.ExceptionsCustom
{
    public class EmailConfirmedException : Exception
    {
        public EmailConfirmedException() : base("This user has already confirmed email") { }
    }
}
