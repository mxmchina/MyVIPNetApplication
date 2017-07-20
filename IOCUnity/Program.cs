using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using Microsoft.Practices.Unity.Configuration;
using Mxm.Interface;
using System.Net;
using System.ServiceModel;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace IOCUnity
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                {
                    string serviceUrl = "http://11.10.166.74:8090/SCADA/HomeSCADAService.svc";


                    ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

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
                    //binding.MessageEncoding = WSMessageEncoding.Text;
                    //binding.TextEncoding = Encoding.UTF8;

                    EndpointAddress addr = new EndpointAddress(serviceUrl);

                    ChannelFactory<HomeSCADAService> _serviceFactory;
                    _serviceFactory = new ChannelFactory<HomeSCADAService>(binding, addr);

                    HomeSCADAService service = _serviceFactory.CreateChannel();

                    service.ExecuteOilAmountService(DateTime.Parse("2017-7-12 07:31"));

                }


                {
                    IUnityContainer container = new UnityContainer();
                    ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                    fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config.xml");//找配置文件的路径
                    Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                    UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);

                    section.Configure(container, "testContainer");//注册

                    Iphone phone = container.Resolve<Iphone>();
                    phone.Call();

                    Console.Read();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
