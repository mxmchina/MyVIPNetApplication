using MyVIPNetApplication.Bridge.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVIPNetApplication.Bridge.Phone
{
    public abstract class BasePhoneBridge
    {

        protected ISystem _ISystem = null;
        public BasePhoneBridge(ISystem system)
        {
            this._ISystem = system;
        }

        public int Id { get; set; }

        public string Remark { get; set; }

        public void Show()
        {
            Console.WriteLine("This is a phone");
        }

        public void Call()
        {
            Console.WriteLine($"use {this.GetType().Name} OS {this.System()} Call");
        }

        public void Test()
        {
            Console.WriteLine($"use {this.GetType().Name} OS {this.System()} Test");
        }

        /// <summary>
        /// 子类都有但各不相同
        /// </summary>
        /// <returns></returns>
        public abstract string System();

    }
}
