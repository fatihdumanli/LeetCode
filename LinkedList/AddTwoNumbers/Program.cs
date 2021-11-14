using System;
using System.Collections.Generic;
using Common;

namespace AddTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            ListNode l1 = new ListNode(2);
            l1.next = new ListNode(4);
            l1.next.next = new ListNode(3);

            ListNode l2 = new ListNode(5);
            l2.next = new ListNode(6);
            l2.next.next = new ListNode(4);
            */

            var l1 = new ListNode(9);
            l1.next = new ListNode(9);
            l1.next.next = new ListNode(9);
            l1.next.next.next = new ListNode(9);
            l1.next.next.next.next = new ListNode(9);
            l1.next.next.next.next.next = new ListNode(9);
            l1.next.next.next.next.next.next = new ListNode(9);

            var l2 = new ListNode(9);
            l2.next = new ListNode(9);
            l2.next.next = new ListNode(9);
            l2.next.next.next = new ListNode(9);
            
            AddTwoNumbers(l1, l2);
            Console.WriteLine("Hello World!");
        }

        static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var newHead = SumNodes(l1, l2, 0);
            return newHead;
        }


        static ListNode SumNodes(ListNode node1, ListNode node2, int carry)
        {
            if (node1 == null && node2 == null && carry == 0)
                return null;

            int x = node1 == null ? 0 : node1.val;
            int y = node2 == null ? 0 : node2.val;

            var sum = x + y + carry;

            return new ListNode(sum % 10) {next = SumNodes(node1?.next, node2?.next, sum / 10)};
        }
        
        
        
    }
}
