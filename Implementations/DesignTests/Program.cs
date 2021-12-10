using System;
using System.Collections.Generic;
using HashMap;
using HashSet;

namespace DesignTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashset = new MyHashSet();
            
            hashset.Add(1);
            hashset.Add(2);
            hashset.Add(2);
            hashset.Remove(2);
            var contains = hashset.Contains(2);

            var hashmap = new MyHashMap();
            hashmap.Put(1, 2);
            hashmap.Remove(1);
            
            hashmap.Put(1, 2);
            hashmap.Put(1, 3);
            
            hashmap.Put(2, 9);

            var result = hashmap.Get(2);
            var result2 = hashmap.Get(9);
        }
    }
}
