using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVIPNetApplication.Linq
{
    public class LinqToObjectShow
    {
        public static void Show()
        {
            List<int> intlist = new List<int>()
            {
                123,12345,2,4,5,7,9,8
            };

            //找出大于10的数据
            var list = intlist.Where(i => i > 10).ToList(); 

            var list2 = Enumerable.Where<int>(intlist, i => i > 10).ToList(); 

            var list3 = MxmLing<int>.MxmWhere(intlist, i => i > 10).ToList(); 
        }

    }
}
