using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mxm.Interface;

namespace Mxm.ServiceExtend
{
    public class ApplePhone : Iphone
    {
        public void Call()
        {
            Console.WriteLine($"{this.GetType().Name}打电话2");
        }
    }
}
