using MyVIPNetApplication.Bridge.Phone;
using MyVIPNetApplication.Bridge.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVIPNetApplication.Bridge
{

    public class BridgeShow
    {
        public static void Show()
        {
            ISystem ios = new IOSSystem();
            ISystem android = new AndroidSystem();
            ISystem windows = new WindowsSystem();

            {
                BasePhoneBridge phone = new IphoneBridge(ios);
                phone.Test();
                phone.Call();
            }

            {
                BasePhoneBridge phone = new P10Bridge(windows);
                phone.Test();
                phone.Call();
            }

        }
    }
}
