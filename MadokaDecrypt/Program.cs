using System;
using System.IO;
using System.Linq;
using System.Text;
using Xxtea;

namespace MadokaDecrypt
{
    class Program
    {
        const string EncryptMagicNumber = "aimyle";

        static void Main(string[] args)
        {
            var key = "DhbUnJeJ3s6NcLtSvR1TJuVt891zaWXFZQvtM7b2sJHvCxp9noZ2fck";

            var bytes = File.ReadAllBytes("ui_com_bk_card_boss1.png");
            if (Encoding.UTF8.GetString(bytes.Take(6).ToArray()) != EncryptMagicNumber)
            {
                Console.WriteLine("this file is not encrypted");
                return;
            }
            bytes = bytes.Skip(6).ToArray();

            var decrypt_data = XXTEA.Decrypt(bytes, key);

            if (decrypt_data != null)
            {
                File.WriteAllBytes("out.png", decrypt_data);
            }
            else
            {
                Console.WriteLine("failed");
            }
        }
    }
}
