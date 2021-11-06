using System;
using System.Collections.Generic;

namespace ReverseLinkedList
{
    class Node
    {
        public int val;
        public Node next;

        public Node(int value)
        {
            val = value;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {

            var node = new Node(1);
            node.next = new Node(2);
            node.next.next = new Node(3);
            
            var result = Reverse(node);
            
        }

        private static Node newHead;
        static Node Reverse(Node node)
        {
            if (node == null)
                return null;

            Reverse(node.next);

            if (node.next == null)
            {
                newHead = node;
            }

            else
            {
                node.next.next = node;
                node.next = null;
            }

            return newHead;
        }

    }
}