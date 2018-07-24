using System.Collections.Generic;

namespace LRUCache
{
    public class LruCache
    {
        private readonly int maxCapacity = 0;
        private readonly Dictionary<int, CacheNode<int, int>> buffer;
        private CacheNode<int, int> head = null;
        private CacheNode<int, int> tail = null;

        public LruCache(int maxCapacity)
        {
            this.maxCapacity = maxCapacity;
            buffer = new Dictionary<int, CacheNode<int, int>>();
        }

        public void Set(int key, int value)
        {
            if (buffer.ContainsKey(key))
            {
                //value exists, so update it and make it the most recently used
                buffer[key].Data = value;
                
                MakeMostRecentlyUsed(buffer[key]);
                return;
            }
            // if count exceed, remove the least used
            if (buffer.Count >= maxCapacity)
            {
                RemoveLeastRecentlyUsed();
            }

            CacheNode<int, int> newNode = new CacheNode<int, int>(value, key);

            if (head == null)
            {
                head = newNode;
                tail = head;
            }
            else
            {
                MakeMostRecentlyUsed(newNode);
            }

            buffer.Add(key, newNode);
        }

        public int Get(int key)
        {
            if (!buffer.ContainsKey(key)) return 0;

            MakeMostRecentlyUsed(buffer[key]);

            return buffer[key].Data;
        }

        //public int Size()
        //{
        //    return _lruCache.Count();
        //}

        //public string CacheFeed()
        //{
        //    var headReference = _head;

        //    List<string> items = new List<string>();

        //    while (headReference != null)
        //    {
        //        items.Add(String.Format("[V: {0}]", headReference.Data));
        //        headReference = headReference.Next;
        //    }

        //    return String.Join(",", items);
        //}

        private void MakeMostRecentlyUsed(CacheNode<int, int> foundItem)
        {
            if (head == foundItem)
            {
                return;
            }

            // Newly inserted item bring to the top and make the current head as the next
            if (foundItem.Next == null && foundItem.Previous == null)
            {
                foundItem.Next = head;
                head.Previous = foundItem;
                if (head.Next == null) tail = head;
                head = foundItem;
            }
            // If it is the tail than bring it to the top
            else if (foundItem.Next == null && foundItem.Previous != null)
            {
                foundItem.Previous.Next = null;
                tail = foundItem.Previous;
                foundItem.Next = head;
                head.Previous = foundItem;
                head = foundItem;
            }
            // If it is an element in between than bring it to the top
            else if (foundItem.Next != null && foundItem.Previous != null)
            {
                foundItem.Previous.Next = foundItem.Next;
                foundItem.Next.Previous = foundItem.Previous;
                foundItem.Next = head;
                head.Previous = foundItem;
                head = foundItem;
            }
            // Last case would be to check if it is a head 
            // but if it is than there is no need to bring it to the top
        }

        private void RemoveLeastRecentlyUsed()
        {
            //remove the current tail.
            buffer.Remove(tail.Key);
            tail.Previous.Next = null;
            tail = tail.Previous;
        }
    }
}
