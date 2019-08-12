using System;

namespace IDE.BLL.ExceptionsCustom
{
    public class ExpiredRefreshTokenException: Exception
    {
        public ExpiredRefreshTokenException(): base("refresh token expired")
        {

        }
    }
}
