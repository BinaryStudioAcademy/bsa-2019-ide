using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.BLL.ExceptionsCustom
{
    public class ExpiredRefreshTokenException: Exception
    {
        public ExpiredRefreshTokenException(): base("refresh token expired")
        {

        }
    }
}
