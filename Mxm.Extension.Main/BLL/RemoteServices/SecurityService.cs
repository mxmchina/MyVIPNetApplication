using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Mxm.Extension.Main.BLL.RemoteServices
{
    public class SecurityService
    {

        private string _key = "5h/AOnV/K9U=";
        private string _iv = "O39NRnz2A5Y=";

        public string Encrypt(string content)
        {
            DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider();
            desProvider.KeySize = 64;

            desProvider.GenerateIV();
            desProvider.GenerateKey();

            var iv = Convert.ToBase64String(desProvider.IV);
            var key = Convert.ToBase64String(desProvider.Key);

            var strKeyIV = Encrypt(key + iv, _key, _iv);

            return strKeyIV + Encrypt(content, key, iv);

        }

        public string Decrypt(string content)
        {
            var strEKeyIV = content.Substring(0, 44);
            var strEContent = content.Substring(44);

            var strDKeyIV = Decrypt(strEKeyIV, _key, _iv);

            var strKey = strDKeyIV.Substring(0, 12);
            var strIV = strDKeyIV.Substring(12, 12);

            return Decrypt(strEContent, strKey, strIV);
        }


        public string Hash(string content)
        {
            byte[] byteList = null; ;
            using (SHA256 s256 = new SHA256Managed())
            {
                byteList = s256.ComputeHash(new UTF8Encoding().GetBytes(content));
                s256.Clear();
            }

            return Convert.ToBase64String(byteList);
        }


        private string Encrypt(string content, string strKey, string strIV)
        {
            content = Convert.ToBase64String(new UTF8Encoding().GetBytes(content));
            byte[] key = Convert.FromBase64String(strKey);
            byte[] iv = Convert.FromBase64String(strIV);

            byte[] byteContent = Convert.FromBase64String(content);
            byte[] byteEncryptionContent;
            string strEncryptionContent;

            using (MemoryStream stream = new MemoryStream())
            {
                DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider();



                CryptoStream encStream = new CryptoStream(stream, desProvider.CreateEncryptor(key, iv), CryptoStreamMode.Write);
                encStream.Write(byteContent, 0, byteContent.Length);
                encStream.FlushFinalBlock();
                stream.Position = 0;
                byteEncryptionContent = new byte[stream.Length];
                stream.Read(byteEncryptionContent, 0, (int)stream.Length);

                stream.Close();
            }

            strEncryptionContent = Convert.ToBase64String(byteEncryptionContent);

            return strEncryptionContent;
        }

        private string Decrypt(string content, string strKey, string strIV)
        {
            byte[] key = Convert.FromBase64String(strKey);
            byte[] iv = Convert.FromBase64String(strIV);

            byte[] byteContent = Convert.FromBase64String(content);
            byte[] byteEncryptionContent;
            string strEncryptionContent;

            using (MemoryStream stream = new MemoryStream())
            {
                DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider();
                CryptoStream encStream = new CryptoStream(stream, desProvider.CreateDecryptor(key, iv), CryptoStreamMode.Write);
                encStream.Write(byteContent, 0, byteContent.Length);
                encStream.FlushFinalBlock();
                stream.Position = 0;
                byteEncryptionContent = new byte[stream.Length];
                stream.Read(byteEncryptionContent, 0, (int)stream.Length);

                stream.Close();
            }
            strEncryptionContent = new UTF8Encoding().GetString(byteEncryptionContent);
            //strEncryptionContent = Convert.ToBase64String(byteEncryptionContent);
            //strEncryptionContent = new UTF8Encoding().GetString(Convert.FromBase64String(strEncryptionContent));

            return strEncryptionContent;
        }
    }
}
