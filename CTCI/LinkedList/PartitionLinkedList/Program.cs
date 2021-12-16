using System;
using Common;

namespace PartitionLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var head = new ListNode(4);
            head.next = new ListNode(2);
            head.next.next = new ListNode(5);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(1);
            head.next.next.next.next.next = new ListNode(3);
            head.next.next.next.next.next.next = new ListNode(6);
            
            // 4 -> 9 -> 5 -> 4 -> 1 -> 3 -> 6 -> NULL

            var result = Partition(head, 3);
            var result2 = Partition2(head, 3);

        }

        static ListNode Partition2(ListNode node, int pivot)
        {
            ListNode head = node;
            ListNode tail = node;

            while (node != null)
            {
                ListNode next = node.next;

                if (node.val < pivot)
                {
                    node.next = head;
                    head = node;
                }

                else
                {
                    tail.next = node;
                    tail = node;
                }

                node = next;
            }

            tail.next = null;
            return head;
        }
        static ListNode[] Partition(ListNode head, int pivot)
        {
            ListNode head1 = new ListNode();
            ListNode head2 = new ListNode();

            ListNode ptr1 = head1;
            ListNode ptr2 = head2;
            
            while (head != null)
            {
                if (head.val < pivot)
                {
                    ptr1.next = new ListNode(head.val);
                    ptr1 = ptr1.next;
                }
                
                else if (head.val >= pivot)
                {
                    ptr2.next = new ListNode(head.val);
                    ptr2 = ptr2.next;
                }

                head = head.next;
            }

            return new []{ head1.next, head2.next};
        }
    }
}
