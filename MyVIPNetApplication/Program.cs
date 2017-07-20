using MyVIPNetApplication.Bridge;
using MyVIPNetApplication.Bridge.Phone;
using MyVIPNetApplication.Delegate;
using MyVIPNetApplication.Delegate.Event;
using MyVIPNetApplication.Linq;
using MyVIPNetApplication.Reflection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVIPNetApplication
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {


                {
                    ReflectionTest.Show();
                }


                {
                    /*
                      桥接模式：解决多维度的变化
                      结构型设计模式:关注类与类直接的关系
                      组合优于继承
                     */

                    BridgeShow.Show();
                }

                {
                    /*字符串拼接*/
                    List<string> dxlist = new List<string>() { "123", "adfas", "asdfasdfasdf" };

                    var resultStr = dxlist.Aggregate((x, y) => x + "','" + y);

                }


                CatPram cat = new CatPram();
                cat.Start();

                Console.WriteLine("程序开始");

                LinqToObjectShow.Show();

                #region 委托
                {
                    Student student = new Student()
                    {
                        Id = 1,
                        Name = "abc"
                    };

                    //测试github提交同步
                    /*
                     action的调用
                     */
                    DelegateExtend.SafeInvoke(() => {
                        student.Study();
                    });


                    student.Study();

                    {
                        /*先实例话一个委托*/
                        Student.SayHiDelegate method = new Student.SayHiDelegate(student.SayHiChinese);
                        student.SayHiPerFect("小明", method);
                    }

                    {
                        /*先实例话一个委托*/
                        Student.SayHiDelegate method = new Student.SayHiDelegate(student.SayHiJapanese);
                        student.SayHiPerFect("小明", method);
                    }

                }
                #endregion

                


                Console.ReadLine();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
