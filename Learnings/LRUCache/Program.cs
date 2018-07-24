using System;

namespace LRUCache
{
    class Program
    {
        static void Main(string[] args)
        {
            LruCache lruCache = new LruCache(5);

            //Console.WriteLine(lruCache.Size());

            lruCache.Set(2, 1);
            lruCache.Set(2, 2);
            int res = lruCache.Get(2);
            Console.WriteLine("result returned :" + res);
            lruCache.Set(1, 1);
            lruCache.Set(4, 1);
            int res1 = lruCache.Get(2);
            Console.WriteLine("result returned :" + res1);
            //lruCache.Insert(3, 50);
            Console.ReadLine();
        }
    }
}
