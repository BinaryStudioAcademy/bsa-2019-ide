using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace IDE.Common.Security
{
    public class SecurityHelper
    {
        public static string HashPassword(string password, byte[] salt)
            => Convert.ToBase64String(
               KeyDerivation.Pbkdf2(
                   password: password,
                   salt: salt,
                   prf: KeyDerivationPrf.HMACSHA256,
                   iterationCount: 10000,
                   numBytesRequested: 256 / 8 //Key length
               )
           );

        public static byte[] GetRandomBytes(int length = 32)
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var salt = new byte[length];

                randomNumberGenerator.GetBytes(salt);

                return salt;
            }
        }

        public static bool ValidatePassword(string password, string hash, string salt)
        {
            return HashPassword(password, Convert.FromBase64String(salt)) == hash;
        }
    }
}
