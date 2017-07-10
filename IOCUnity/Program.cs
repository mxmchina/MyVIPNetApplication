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

namespace IOCUnity
{
    class Program
    {
        static void Main(string[] args)
        {

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
    }
}
