using System;
using Common;

namespace DeleteTheMiddleNode
{
    class Program
    {
        static void Main(string[] args)
        {
            var head = new ListNode(2);
            head.next = new ListNode(1);

            var result = DeleteMiddle(head);
        }

        static ListNode DeleteMiddle(ListNode head)
        {
            if (head.next == null)
                return null;
            
            int n = 0;
            var temp = head;
            while (temp != null)
            {
                n++;
                temp = temp.next;
            }

            n /= 2;
            var ptr = head;
            for (int i = 0; i < n; i++)
            {
                if (ptr.next.next == null)
                {
                    ptr.next = null;
                    return ptr;
                }
                
                ptr = ptr.next;

                if (i + 1 == n)
                {
                    ptr.next = ptr.next.next;
                }
            }
            
            return head;
        }
    }
}
