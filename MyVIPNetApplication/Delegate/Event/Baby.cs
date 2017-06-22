using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVIPNetApplication.Delegate.Event
{
    public class Baby
    {
        public void Cry()
        {
            Console.WriteLine("{0}Cry", this.GetType().Name);
        }
    }
}
