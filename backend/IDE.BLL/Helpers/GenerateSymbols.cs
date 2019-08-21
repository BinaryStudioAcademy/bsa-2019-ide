using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.BLL.Helpers
{
    public static class GenerateSymbols
    {
        private static readonly char[] AvailibleChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        public static string GenerateRandomSymbols(int count = 50)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            int charsCount = AvailibleChars.Length;
            char[] charArray = new char[count];
            for (int i = 0; i < count; i++)
            {
                charArray[i] = AvailibleChars[random.Next(charsCount)];
            };
            return string.Join("", charArray);
        }
    }
}
