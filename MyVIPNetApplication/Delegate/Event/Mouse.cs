using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVIPNetApplication.Delegate.Event
{
    public class Mouse
    {
        public void Run()
        {
            Console.WriteLine($"{this.GetType().Name}Run");
        }
    }
}
