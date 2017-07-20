using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVIPNetApplication.Reflection
{
    public class ReflectionTest
    {
        public static void Show()
        {
            /*反射操作字段属性*/

            Type type = typeof(Iphone);
            object phone = Activator.CreateInstance(type);

            foreach (var property in type.GetProperties())
            {
                Type tt = property.PropertyType;
                Console.WriteLine(string.Format("Iphone.{0}={1}", property.Name, property.GetValue(phone)));
            }

            foreach (var filed in type.GetFields())
            {

                Type tt = filed.FieldType;

                filed.SetValue(phone, "1234");
                Console.WriteLine(string.Format("Iphone.{0}={1}", filed.Name, filed.GetValue(phone)));
            }
        }
    }
}
