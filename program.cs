using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace sharp_alienum
{
    class Program
    {
        private static byte[] _rgbKey = Encoding.ASCII.GetBytes("<REDACTED>");
        private static byte[] _rgbIV = Encoding.ASCII.GetBytes("<REDACTED>");
        static void Main(string[] args)
        {
            Console.WriteLine(Decrypt("<REDACTED>"));
            Console.WriteLine(Decrypt("<REDACTED>"));
        }

        public static string Decrypt(string cryptedString)
        {
            try
            {
                if (string.IsNullOrEmpty(cryptedString))
                    return string.Empty;
                DESCryptoServiceProvider cryptoServiceProvider = new DESCryptoServiceProvider();
                return new StreamReader((Stream)new CryptoStream((Stream)new MemoryStream(Convert.FromBase64String(cryptedString)), cryptoServiceProvider.CreateDecryptor(Program._rgbKey, Program._rgbIV), CryptoStreamMode.Read)).ReadToEnd();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return string.Empty;
            }
        }

    }
}
