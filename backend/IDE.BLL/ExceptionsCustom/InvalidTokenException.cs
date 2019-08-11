using System;

namespace IDE.BLL.ExceptionsCustom
{
    public class InvalidTokenException : Exception
    {
        public InvalidTokenException(string tokenName) : base($"invalid token {tokenName}")
        {

        }
    }
}
