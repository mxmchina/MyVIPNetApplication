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

        }
    }
}
