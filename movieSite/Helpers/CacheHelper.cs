using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace movieSite.Helpers
{
    public static class CacheHelper
    {
        public static T Get<T>(string key) where T : class
        {
            return (T)HttpRuntime.Cache.Get(key);
        }
        public static void Add(string key, object item)
        {
            HttpRuntime.Cache.Insert(key, item);
        }
        public static void RemoveCache(string key)
        {
            HttpRuntime.Cache.Remove(key);
        }
        

    }
}