using System;


namespace HashSet
{
    public class Node
    {
        public int val;
        public Node next;

        public Node(int _val)
        {
            this.val = _val;
        }
    }
    
    /// <summary>
    /// Leetcode 705. Design Hashset
    /// https://leetcode.com/problems/design-hashset/
    /// </summary>
    public class MyHashSet
    {
        private const int ARRAY_SIZE = 100;
        private Node[] nodes = new Node[ARRAY_SIZE];

        public void Add(int value)
        {
            var index = value % ARRAY_SIZE;
            var head = nodes[index];

            if (head == null)
            {
                nodes[index] = new Node(value);
                return;
            }

            if (head.val == value)
                return;
            
            while (head.next != null)
            {
                if (head.next.val == value)
                    return;
                
                head = head.next;
            }

            head.next = new Node(value);
        }

        public bool Contains(int value)
        {
            var index = value % ARRAY_SIZE;

            var head = nodes[index];

            if (head == null)
                return false;

            while (head != null)
            {
                if (head.val == value)
                    return true;
                
                head = head.next;
            }
            
            return false;
        }

        public void Remove(int value)
        {
            var index = value % ARRAY_SIZE;
            var head = nodes[index];

            if (head == null)
                return;

            if (head.val == value)
            {
                nodes[index] = nodes[index].next;
                return;
            }

            var current = head;
            while (current.next != null)
            {
                if (current.next.val == value)
                {
                    current.next = current.next.next;
                    return;
                }

                current = current.next;
            }
        }
    }
}
