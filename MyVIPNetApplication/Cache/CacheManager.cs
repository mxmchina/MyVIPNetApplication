using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVIPNetApplication.Cache
{
    /// <summary>
    /// 单例模式实现一个缓存类
    /// </summary>
    public class CacheManager
    {
        private static ICache cache = null;

        private CacheManager()
        {

        }

        static CacheManager()
        {
            Console.WriteLine("开始缓存的初始化。。。。");

            cache = (ICache)Activator.CreateInstance(typeof(MemoryCacheCache));
        }

        public static int Count
        {
            get { return CacheManager.cache.Count; }
        }

        /// <summary>
        /// 设置缓存并返回缓存对象，有则返回没有则添加并返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">缓存的项</param>
        /// <param name="acquire">没有缓存的时候获取数据的方法</param>
        /// <param name="cacheTime">单位分钟 默认时间30</param>
        /// <returns></returns>
        public static T Get<T>(string key, Func<T> acquire, int cacheTime = 30)
        {
            if (!cache.Contains(key))
            {
                T result = acquire.Invoke();
                cache.Add(key,result,cacheTime);
            }
            return cache.Get<T>(key);
        }
    }
}
