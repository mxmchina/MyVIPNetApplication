using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mxm.Extension.Main.BLL.RemoteServices;
using System.Net.Http;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
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
