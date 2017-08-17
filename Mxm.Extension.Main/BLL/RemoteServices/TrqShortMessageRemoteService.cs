using Mxm.Extension.Main.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mxm.Extension.Main.BLL.RemoteServices
{
    public class TrqShortMessageRemoteService
    {

        public bool Send(string phones,string content)
        {
            StringBuilder phonesSb = new StringBuilder();
            phones.Split(',').ToList().ForEach(p=> {

                if (Regex.IsMatch(p.Trim(), "0?(13|14|15|17|18)[0-9]{9}"))
                {
                    phonesSb.Append(p.Trim()).Append(","); ;
                }
            });

            string phonesStr = string.Empty;
            if (phonesSb.Length > 0)
            {
                phonesStr = phonesSb.ToString().Substring(0, phonesSb.Length - 1);
            }

            string b2mUrl = ConfigurationManager.AppSettings["TRQSHORTMESSAGEESERVICEURL"];

            string cdkey = "8SDK-EMY-6699-RIQTM";
            string password = "314313";
            string phone = phonesStr;
            string msgContent = "【中国石油】" + content.Replace('【', '[').Replace('】', ']');

            string token = this.GetToken();

            b2mUrl += "?cdkey=" + cdkey + "&message=" + System.Web.HttpUtility.UrlEncode(msgContent) + "&password=" + password + "&phone=" + phone + "&token=" + System.Web.HttpUtility.UrlEncode(token);
            string messageResult = string.Empty;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = client.GetAsync(b2mUrl).Result;

                    messageResult = response.Content.ReadAsStringAsync().Result.Trim();

                }
            }
            catch (Exception ex)
            {
                throw new UtilityException((int)Errors.CommunicationError, ex.ToString());
            }

            var xelementReslut = XElement.Parse(messageResult.ToString());

            bool result = false;

            if (xelementReslut.Element("error") != null && xelementReslut.Element("error").Value == "0")
            {
                result = true;
            }

            return result;
        }

        #region 获取token

        private string GetToken()
        {
            //trq1;6818151b-6713-e611-80c5-0050569d20fb;636384694750520386

            var token = "trq" + ";" + Guid.NewGuid() + ";" + DateTime.UtcNow.Ticks;
            var encToken = this.Encrypt(token);

            return encToken;
        }


        private string _key = "5h/AOnV/K9U=";
        private string _iv = "O39NRnz2A5Y=";

        private string Encrypt(string content)
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

        #endregion
    }
}
