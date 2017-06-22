using MyVIPNetApplication.Delegate;
using MyVIPNetApplication.Delegate.Event;
using MyVIPNetApplication.Linq;
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
