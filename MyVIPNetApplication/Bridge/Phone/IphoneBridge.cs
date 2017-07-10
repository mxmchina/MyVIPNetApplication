using MyVIPNetApplication.Bridge.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVIPNetApplication.Bridge.Phone
{
    public class IphoneBridge : BasePhoneBridge
    {

        public IphoneBridge(ISystem system)
            :base(system)
        {

        }

        public override string System()
        {
            return this._ISystem.System();
        }
    }
}
