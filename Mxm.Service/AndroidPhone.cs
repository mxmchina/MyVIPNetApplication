using Mxm.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mxm.Service
{
    public class AndroidPhone : Iphone
    {
        public void Call()
        {
            Console.WriteLine($"{this.GetType().Name}打电话");
        }

    }
}
