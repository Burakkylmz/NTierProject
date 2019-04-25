using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NTierProject.Utility
{
    public class Cryptography
    {
        public static string ToMD5(string text)
        {
            //https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.md5cryptoserviceprovider?view=netframework-4.8 


            if (text != null)
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

                byte[] array = Encoding.UTF8.GetBytes(text);

                array = md5.ComputeHash(array);

            //https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder?view=netframework-4.8*/

                StringBuilder sb = new StringBuilder();

                foreach (byte ba in array)
                {
                    sb.Append(ba.ToString("x2").ToLower());
                }

                return sb.ToString();
            }
            else
            {
                return text;
            }
        }

    }
}
