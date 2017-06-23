using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVIPNetApplication.Generic
{

    /*泛型*/

    /// <summary>
    /// 逆变：子类型转变为父类型
    /// 协变：父类型转变为子类型
    /// </summary>
    public class GenericTest
    {
        static void Test()
        {
            IContravariantIn<Sample1> iobj = new SampleIn<Sample>();//把父类型转变为子类型 逆变
            IContravariantOut<Sample> istr = new SampleOut<Sample1>();//把子类型转变为父类型 协变

        }
    }

    interface IContravariantIn<in A> { }//接口 包含一个泛型的可逆变类

    interface IContravariantOut<out A> { }//接口 包含一个泛型可协变类

    class Sample { }//父类型

    class Sample1 : Sample { }//子类型继承父类型

    class SampleOut<A> : IContravariantOut<A> { }

    class SampleIn<A> : IContravariantIn<A> { }

}
