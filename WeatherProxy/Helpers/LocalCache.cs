using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace WeatherProxy.Helpers
{
    public class LocalCache
    {
        private static LocalCache _instance;
        private static object lockObject = new object();
        private static ObjectCache cache;

        protected LocalCache()
        {
            cache = MemoryCache.Default;
        }

        public static LocalCache Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (_instance == null)
                        _instance = new LocalCache();
                    return _instance;
                }
            }
        }

        public void Add<T>(T item, string name)
        {
            cache[name] = item;
        }

        public T Get<T>(string name) where T : class
        {
            return cache[name] as T;
        }

        public void Remove(string name)
        {
            cache.Remove(name);
        }
    }
}
