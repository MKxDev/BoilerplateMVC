using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBase.Common.Utilities
{
    public static class Utils
    {
        private static readonly Random random = new Random();
        private const string randomCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public static string GetRandomString(int length = 20)
        {
            var buffer = new char[length];

            for (var i = 0; i < length; i++)
            {
                buffer[i] = randomCharacters[random.Next(length)];
            }

            return new string(buffer);
        }
    }
}
