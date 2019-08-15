using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.BLL.ExceptionsCustom
{
    public class ExistedUserLoginException: Exception
    {
        public ExistedUserLoginException():base("This E-mail is existed")
        {

        }
    }
}
