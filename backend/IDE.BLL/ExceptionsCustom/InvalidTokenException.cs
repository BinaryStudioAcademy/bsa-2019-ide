using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.BLL.ExceptionsCustom
{
    public class InvalidTokenException : Exception
    {
        public InvalidTokenException(string tokenName) : base($"invalid token {tokenName}")
        {

        }
    }
}
