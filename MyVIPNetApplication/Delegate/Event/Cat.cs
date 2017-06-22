using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVIPNetApplication.Delegate.Event
{
    /// <summary>
    /// 毛叫一声之后会触发一系列的动作
    /// 
    /// 可以利用多播委托实现
    /// </summary>
    public class Cat
    {

        public Action MiaoHandler;

        public void MiaoDelegate()
        {
            Console.WriteLine("{0}MiaoDelegate",this.GetType().Name);

            if (MiaoHandler != null)
            {
                MiaoHandler.Invoke();
            }
        }


        /// <summary>
        /// 事件是委托的实例，加上event关键字
        /// 委托是一种类型，事件是委托的一种实例
        /// event关键字可以控制权限，保障安全
        /// 保证委托实例只能被+= -= ，不能赋值 不能invoke
        /// 
        /// 事件可能有默认动作不希望被外面破坏
        /// 不能直接调用
        /// </summary>
        public event Action MiaoHandlerEvent;

        public void MiaoEvent()
        {
            Console.WriteLine("{0}MiaoEvent", this.GetType().Name);

            if (MiaoHandler != null)
            {
                MiaoHandler.Invoke();
            }
        }
    }
}
