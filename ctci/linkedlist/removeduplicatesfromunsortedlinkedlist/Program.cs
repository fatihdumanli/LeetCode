using System;
using System.Collections.Generic;
using Common;

namespace RemoveDuplicatesFromUnsortedLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode head = new ListNode(3);
            head.next = new ListNode(3);
            head.next.next = new ListNode(2);
            head.next.next.next = new ListNode(1);
            head.next.next.next.next = new ListNode(2);

            
            //head.next.next.next = new ListNode(1);
            
            /*
            head.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next = new ListNode(1);
            head.next.next.next.next.next.next = new ListNode(3);
            */

            var result = RemoveDuplicates(head);
            result = RemoveDuplicatesWithoutHashset(head);
            Console.WriteLine("Hello World!");
        }

        //O(N^2) without a hashset.
        static ListNode RemoveDuplicatesWithoutHashset(ListNode head)
        {
            var first = head;
            var second = head.next;
            while (first != null)
            {
                var num = first.val;
                if (second != null && second.val == num)
                {
                    first = second;
                    second = first.next;
                    continue;
                }
                
                while (second != null)
                {
                    if (second.next == null)
                        break;
                    if (second.next.val == num)
                        second.next = second.next.next;
                    else
                        second = second.next;
                }
                first = first.next;
            }
            return head;
        }
        
        // O(N) with a hashset.
        static ListNode RemoveDuplicates(ListNode head)
        {
            HashSet<int> values = new HashSet<int>();
            
            var current = head;
            ListNode previous = null;
            
            while (current != null)
            {
                if (values.Contains(current.val))
                    previous.next = current.next;

                else
                {
                    previous = current;
                    values.Add(current.val);
                }
                current = current.next;
            }
            return head;
        }
    }
}
