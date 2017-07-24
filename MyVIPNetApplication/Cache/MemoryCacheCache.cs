using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyVIPNetApplication.Cache
{
    public class MemoryCacheCache : ICache
    {
        protected ObjectCache Cache { get { return MemoryCache.Default; } }

        public MemoryCacheCache()
        {

        }

        public object this[string key]
        {
            get
            {
                return Cache.Get(key);
            }

            set
            {
                this.Add(key, value);
            }
        }

        public int Count
        {
            get
            {
                return (int)this.Cache.GetCount(); ;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="cacheTime">分钟</param>
        public void Add(string key, object data, int cacheTime = 30)
        {
            if (data == null) { return; }

            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime);
            Cache.Add(new CacheItem(key, data), policy);
        }

        public bool Contains(string key)
        {
            return this.Cache.Contains(key);
        }

        public T Get<T>(string key)
        {
            if (this.Cache.Contains(key))
            {
                return (T)this.Cache[key];
            }
            else {
                return default(T);
            }
        }

        public object Get(string key)
        {
            return Cache[key];
        }

        public void Remove(string key)
        {
            this.Cache.Remove(key);
        }

        public void RemoveAll()
        {
            foreach (var item in this.Cache)
            {
                this.Cache.Remove(item.Key);
            }
        }

        /// <summary>
        /// 正则表达式移除
        /// </summary>
        /// <param name="pattern">pattern</param>
        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = new List<String>();

            foreach (var item in Cache)
                if (regex.IsMatch(item.Key))
                    keysToRemove.Add(item.Key);

            foreach (string key in keysToRemove)
            {
                Remove(key);
            }
        }
    }
}
