using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mxm.Extension.Main.BLL.RemoteServices;
using System.Net.Http;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Text;
using Mxm.Extension.Main.BLL;
using System.Data;
using Limilabs.Mail;
using System.Collections.Generic;
using Limilabs.Client.IMAP;
using Limilabs.Mail.MIME;
using System.Text.RegularExpressions;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        /// <summary>
        /// 读取邮件的方法
        /// </summary>
        [TestMethod]
        public void TestEmail()
        {
            //StringBuilder sb = new StringBuilder();//存放匹配结果

            string sb = "";
            using (Imap imap = new Imap())
            {
                imap.Connect("10.27.130.247");   // or ConnectSSL for SSL
                imap.UseBestLogin("liushuqian", "L2000sq");

                imap.SelectInbox();
                List<long> uids = imap.Search(Flag.All);

                foreach (long uid in uids)
                {
                    IMail email = new MailBuilder()
                        .CreateFromEml(imap.GetMessageByUID(uid));

                    //Console.WriteLine(email.Subject);
                    var su = email.Subject;
                    if (email.Subject.ToLower().Contains("undelivered"))
                    {
                        string body = email.GetBodyAsText();

                        string pattern = @"\<.*?\>";//匹配模式

                        Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

                        MatchCollection matches = regex.Matches(body);

                        foreach (Match match in matches)
                        {
                            string value = match.Value.Trim('(', ')');
                            if (value.Contains("@"))
                            {
                                sb += value + ",";
                            }
                        }

                    }
                }
                imap.Close();
            }
        }



        [TestMethod]
        public void TestMethod1()
        {

            TrqShortMessageRemoteService service = new TrqShortMessageRemoteService();

            service.Send("18500362916", "test1234");
        }

        [TestMethod]
        public void TestMethod2()
        {
            var url = "https://trq.crmprd.cnpc:8080/api/message/send?";

            //var url = "http://localhost:8081/api/message/send?token=";

            string token = new TrqShortMessageRemoteService().GetToken();

            url += token;

            var json = "{'Id':'d1e2b614-bef5-460e-9743-d4b7166283d9','MSGContent':'测试123','ReceivePhoneNumber':'18500362916'}";

            HttpResponseMessage response = null;
            StringContent httpContent = null;

            httpContent = new StringContent(json, new UTF8Encoding(), "application/json");

            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

            using (HttpClient client = new HttpClient())
            {
                response = client.PostAsync(url, httpContent).Result;
            }
        }
    }
}
