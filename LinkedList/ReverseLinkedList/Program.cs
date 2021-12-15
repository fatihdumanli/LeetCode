using System;
using System.Collections.Generic;
using Common;

namespace ReverseLinkedList
{
    class Program
    {
        private static ListNode newHead;

        static void Main(string[] args)
        {
            var head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);

            var newHead = ReverseList(head);
            
            Console.WriteLine("Hello World!");
        }

        
        static ListNode ReverseList(ListNode head)
        {
            if (head.next == null)
                return head;
            var node = ReverseList(head.next);
            head.next.next = head;
            head.next = null;
            return node;
        }
        
    }
}
