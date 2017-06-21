using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVIPNetApplication.Linq
{
    public class MxmLing
    {
        //筛选逻辑
        public static IEnumerable<T> MxmWhere<T>(IEnumerable<T> source, Func<T, bool> predicate)
        {
            List<T> result = new List<T>();
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
