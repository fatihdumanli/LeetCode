using System;
using Common;

namespace RemoveNthNodeFromEndOfList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        
        private int index = 0;

        private static ListNode RemoveNthFromEnd(ListNode head, int n) {
    
            var slow = head;
            var fast = head;
            int fastPtr = 1;
    
            while(fast != null && fast.next != null)
            {
                fast = fast.next.next;
                fastPtr += 2;
            }
         
            if(fast == null)
                fastPtr--;
        
            if(fastPtr - n < 0)
                head = head.next;
        
            for(int i = 0; i < fastPtr - n; i++)
                slow = slow.next;
        
            slow.next = slow.next.next;
    
            return head.next;
        }

    }
}
