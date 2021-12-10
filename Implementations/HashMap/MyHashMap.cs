using System;

namespace HashMap
{
    public class Node
    {
        public int key;
        public int val;
        public Node next;
        
        public Node(int key, int val)
        {
            this.key = key;
            this.val = val;
        }
    }
    
    /// <summary>
    /// LeetCode 706. Design Hashmap
    /// https://leetcode.com/problems/design-hashmap/
    /// </summary>
    public class MyHashMap
    {

        private const int ARRAY_SIZE = 100;
        private Node[] _nodes = new Node[ARRAY_SIZE];

        public MyHashMap() {
        }
    
        public void Put(int key, int value)
        {
            var index = key % ARRAY_SIZE;
            var head = _nodes[index];

            if (head == null)
            {                
                _nodes[index] = new Node(key, value);
                return;
            }

            if (head.key == key)
            {
                head.val = value;
                return;
            }
            
            while (head.next != null)
            {
                if (head.next.key == key)
                {
                    head.next.val = value;
                    return;
                }
                
                head = head.next;
            }

            head.next = new Node(key, value);

        }
    
        public int Get(int key)
        {
            var index = key % ARRAY_SIZE;
            var head = _nodes[index];

            if (head == null)
                return -1;

            while (head != null)
            {
                if (head.key == key)
                    return head.val;

                head = head.next;
            }

            return -1;
        }
    
        public void Remove(int key)
        {
            var index = key % ARRAY_SIZE;
            var head = _nodes[index];

            if (head == null)
                return;

            if (head.key == key)
            {
                _nodes[index] = head.next;
                return;
            }

            while (head.next != null)
            {
                if (head.next.key == key)
                {
                    head.next = head.next.next;
                    return;
                }

                head = head.next;
            }
        }
    }
}
