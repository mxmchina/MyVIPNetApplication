using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVIPNetApplication.Bridge.System;

namespace MyVIPNetApplication.Bridge.Phone
{
    public class P10Bridge : BasePhoneBridge
    {
        public P10Bridge(ISystem system) : base(system)
        {

        }

        public override string System()
        {
            return this._ISystem.System();
        }
    }
}
