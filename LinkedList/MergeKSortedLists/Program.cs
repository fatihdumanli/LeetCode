using System;
using Common;

namespace MergeKSortedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var node1 = new ListNode(2);
            node1.next = new ListNode(1);
            
            var node2 = new ListNode(4);
            node2.next = new ListNode(3);
            

            var node3 = new ListNode(2);
            node3.next = new ListNode(6);

            var list = new ListNode[]
            {
                node1, node2, node3
            };

            var result = MergeKLists(list);
            Console.WriteLine("Hello World!");
        }
        
        static ListNode MergeKLists(ListNode[] lists) {
            ListNode sorted = new ListNode();


            foreach (var node in lists)
            {
                var ptr = node;
                while (ptr != null)
                {
                    sorted = InsertNode(sorted, ptr);
                    ptr = ptr.next;
                }
            }
            
            return sorted.next;
        }
        
        
        static ListNode InsertNode(ListNode sorted, ListNode node)
        {
            ListNode headCopy = sorted;

            if (sorted.next == null)
            {
                sorted.next = new ListNode(node.val);
                return headCopy;
            }

            while(sorted.next != null && node.val >= sorted.next.val)
            {
                sorted = sorted.next;
            }

            var temp = sorted.next;
            sorted.next = new ListNode(node.val);
            sorted.next.next = temp;
    
            return headCopy;
     
        }
        
    }
}
