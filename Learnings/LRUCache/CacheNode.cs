using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUCache
{
    public class CacheNode<D, K>
    {
        public D Data { get; set; }
        public K Key { get; private set; }
        public CacheNode<D, K> Previous { get; set; }
        public CacheNode<D, K> Next { get; set; }

        public CacheNode(D data, K key)
        {
            Data = data;
            Key = key;
        }
    }
}
