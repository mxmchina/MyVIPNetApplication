using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVIPNetApplication.Delegate.Event
{
    //观察者模式
    public class CatPram
    {
        public void Start()
        {
            Cat cat = new Cat();

            /*委托的多播*/
            {
                cat.MiaoHandler += () => { Console.WriteLine("{0}adfadsfa"); };
                cat.MiaoHandler += new Dog().Run;
                cat.MiaoHandler += new Baby().Cry;
                cat.MiaoHandler += new Mouse().Run;

                cat.MiaoDelegate();

                cat.MiaoHandler.Invoke();
            }

            /// event关键字可以控制权限，保障安全
            /// 保证委托实例只能被+= -= ，不能赋值 不能invoke
            /// 
            /// 事件可能有默认动作不希望被外面破坏
            /// 不能直接调用

            /*事件的多播*/
            {
                cat.MiaoHandlerEvent += () => { Console.WriteLine("{0}adfadsfa"); };
                cat.MiaoHandlerEvent += new Dog().Run;
                cat.MiaoHandlerEvent += new Baby().Cry;
                cat.MiaoHandlerEvent += new Mouse().Run;

                //cat.MiaoHandlerEvent.Invoke();
                //cat.MiaoHandlerEvent = null;
                //这样写会报错
                cat.MiaoEvent();


            }
        }
    }
}
