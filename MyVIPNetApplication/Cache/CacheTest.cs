using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVIPNetApplication.Cache
{
    /// <summary>
    /// 缓存
    /// </summary>
    public class CacheTest
    {
        public static void Show()
        {

            MemoryCacheCache cache1 = new MemoryCacheCache();
            cache1.Add("key1","value1");
            cache1.Add("key1", "value3");

            MemoryCacheCache cache2 = new MemoryCacheCache();
            cache1.Add("key1", "value2");

            var result = cache1.Get("key1");


            /*带返回值无参数的委托调用*/
            Func<int> func = () => { return 123; };

            CacheManager.Get<int>("key3", func,40);

            CacheManager.Get<int>("key3", () => 123, 40);

        }


       
    }
}
