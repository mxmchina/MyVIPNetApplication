using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVIPNetApplication.Lambda
{
    /// <summary>
    /// Lambda表达式
    /// </summary>
    public class LambdaTest
    {
        public delegate void NoParaNoReturn();
        public delegate void WithParaNoreturn();



        public void Show()
        {

            #region lambda表达式
            {
                /*
                 Action 可以接收0到16个参数的无返回值的委托
                 */
                Action<int> act2 = i => Console.WriteLine(i);
                Action<int, int> act3 = (i, j) =>
                {

                };


                /*
                 Func 可以带0到16个参数的又返回值的委托
                 */
                Func<int> func1 = new Func<int>(() => { return 1; });
                Func<int> func2 = () => 1;

                Func<string, int> func3 = (s) => { return 123; };

                func3.Invoke("ba");

            }
            #endregion



        }




        private void DoNothing()
        {
            Console.WriteLine("DoNothing");
        }

        private void DoSomething()
        {
            Console.WriteLine("DoSomethine");
        }
    }
}
