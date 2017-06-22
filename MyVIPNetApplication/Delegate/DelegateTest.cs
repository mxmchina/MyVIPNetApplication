using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVIPNetApplication.Delegate
{
    public class DelegateTest
    {
        /// <summary>
        /// 声明一个无返回值的委托
        /// </summary>
        public delegate void NoReturnWithPara(string para);


        public void Show()
        {
            /*
             * 委托的实例之后调用
             */
            {
                NoReturnWithPara method = new NoReturnWithPara(this.ShowIdName);//普通方法
                method.Invoke("小明");
                method("月月");


                NoReturnWithPara method1 = new NoReturnWithPara(DelegateTest.ShowIdNameStatic);//静态方法
                method1.Invoke("小明");

            }

            {
                /*多播委托*/

                NoReturnWithPara method = new NoReturnWithPara(this.ShowIdName);//普通方法
                method += DelegateTest.ShowIdNameStatic;
                method += s => { Console.WriteLine($"Lambda表达式传入的名称为：{s}"); };

                method.Invoke("小明");
                //+=在委托实例上按顺序添加多个方法，形成方法链，invaoke的时候按顺序执行

                //+=在委托实例上从方法尾部开始匹配，遇到第一个吻合的开始移除，且只移除一个，没有也不抛出异常
                method -= this.ShowIdName;
                method -= ShowIdNameStatic;
                method += s => { Console.WriteLine($"Lambda表达式传入的名称为：{s}"); };
                //任何两个lambda表达式都是不一样的 所以不会移除上面的方法
                method.Invoke("阿亮");

            }


            
        }


        private void ShowIdName(string name)
        {
            Console.WriteLine($"传入的名称为：{name}");
        }

        private static void ShowIdNameStatic(string name)
        {
            Console.WriteLine($"静态方法传入的名称为：{name}");
        }
    }
}
