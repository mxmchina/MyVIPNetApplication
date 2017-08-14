using Mxm.Extension.Main.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Mxm.Extension.Main.BLL.RemoteServices
{
    public class ShortMessageRemoteService
    {
        private static ChannelFactory<ISendMessageService> _serviceFactory;

        public ShortMessageRemoteService()
        {
            string serviceUrl = ConfigurationManager.AppSettings["SHORTMESSAGEESERVICEURL"];

            //ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

            BasicHttpBinding binding;
            Uri address = new Uri(serviceUrl);
            if (address.Scheme == "https")
            {
                binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;
            }
            else
            {
                binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
            }

            binding.CloseTimeout = new TimeSpan(3, 0, 0);
            binding.OpenTimeout = new TimeSpan(3, 0, 0);
            binding.ReceiveTimeout = new TimeSpan(3, 0, 0);
            binding.SendTimeout = new TimeSpan(3, 0, 0);
            binding.MaxReceivedMessageSize = 65536000;

            EndpointAddress addr = new EndpointAddress(serviceUrl);

            _serviceFactory = new ChannelFactory<ISendMessageService>(binding, addr);
        }

        public bool Send(string key, string password, string content, string phones)
        {

            SendMessageSubmitRequest request = new SendMessageSubmitRequest();
            request.Body = new SendMessageSubmitRequestBody();
            request.Body.Login = new SendMessageSubmitRequestLogin();
            //用户名
            request.Body.Login.Name = key;
            //密码
            request.Body.Login.Passwd = password;
            request.Body.Submit = new SendMessageSubmitRequestSubmit();
            //发送号码
            request.Body.Submit.DestTermId = phones;
            //内容
            request.Body.Submit.MsgContent = content;
            request.Body.Submit.ServiceId = "wholeSale";
            request.Body.Submit.NeedReport = "0";
            request.Body.Submit.Priority = "2";
            //对方收到后显示的号码
            request.Body.Submit.SrcTermId = "95504";
            request.Body.Submit.Pid = "P" + (DateTime.Now.Ticks / 100000).ToString();

            SendMessageSubmitResponse response = null;
            ISendMessageService service = _serviceFactory.CreateChannel();
            try
            {

                response = service.Submit(request);

            }
            catch (Exception ex)
            {
                try
                {
                    ((ICommunicationObject)service).Abort();
                }
                catch
                {
                }
                throw new UtilityException((int)Errors.CommunicationError, ex.ToString());
            }
            finally
            {
                ((ICommunicationObject)service).Close();
            }

            if (response != null && response.Body.SubmitResult.Head != "1")
            {
                return false;
                //throw new UtilityException((int)Errors.CommunicationError, ex.ToString());
            }

            return true;
        }
    }
}
