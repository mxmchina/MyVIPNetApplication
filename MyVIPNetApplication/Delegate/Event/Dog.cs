using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVIPNetApplication.Delegate.Event
{
    public class Dog
    {
        public void Run()
        {
            Console.WriteLine("{0}Runt", this.GetType().Name);
        }
    }
}
