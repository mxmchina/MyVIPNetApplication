using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVIPNetApplication.Delegate
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public long QQ { get; set; }

        public void Study()
        {
            Console.WriteLine("{0}跟着老师学习.netvip课程",this.Name);
        }


        /// <summary>
        /// 委托
        /// </summary>
        /// <param name="name"></param>
        public delegate void SayHiDelegate(string name);

        /// <summary>
        /// 1.公共逻辑不重复
        /// 2.不包含全部的逻辑分支
        /// 
        /// 委托可以把方法包裹成变量
        /// </summary>
        public void SayHiPerFect(string name, SayHiDelegate method)
        {
            Console.WriteLine("SayHi公共逻辑在这里！");
            method.Invoke(name);
        }

        /// <summary>
        /// 普通写法，多一个类型就多一个判断case语句，维护困难
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        public void SayHi(string name, PeopleType type)
        {
            switch (type)
            {
                case PeopleType.American:
                    Console.WriteLine("{0}早上好！",this.Name);
                    break;
                case PeopleType.Chinese:
                    Console.WriteLine("{0}Mrning!",this.Name);
                    break;
                case PeopleType.Japanese:
                    Console.WriteLine("{0}@#$$%%!", this.Name);
                    break;
                default:
                    throw new Exception ("wrong peopletype");
            }
        }


        /// <summary>
        /// 拆分方法，逻辑简单
        /// </summary>
        /// <param name="name"></param>
        public void SayHiChinese(string name)
        {
            Console.WriteLine("{0}早上好！", name);
        }

        public void SayHiAmerican(string name)
        {
            Console.WriteLine("{0}Mrning！", this.Name);
        }

        public void SayHiJapanese(string name)
        {
            Console.WriteLine("{0}@#$$%%！", this.Name);
        }
        

    }

    public enum PeopleType
    {
        Chinese = 0,
        American = 1,
        Japanese = 2
    }
}
