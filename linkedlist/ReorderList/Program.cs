using System;
using System.Collections.Generic;
using System.Diagnostics;
using Common;

namespace ReorderList
{
    public class LastElementWrapper {
        public ListNode newHead;
        public int lastNodeVal;
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            
            var head = new ListNode(1);

            var headPtr = head;
            for (int i = 0; i < 1000; i++)
            {
                headPtr.next = new ListNode(i);
                headPtr = headPtr.next;
            }

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            ReorderListPtrs(head);

            stopwatch.Stop();
            Console.WriteLine($"Solution with multiple ptrs took {stopwatch.ElapsedTicks} ticks");

            
            head = new ListNode(1);
            headPtr = head;
            for (int i = 0; i < 1000; i++)
            {
                headPtr.next = new ListNode(i);
                headPtr = head.next;
            }
            stopwatch.Reset();
            stopwatch.Start();
            ReorderList(head);
            stopwatch.Stop();
            Console.WriteLine($"Solution with stack/queue took {stopwatch.ElapsedTicks} ticks");


            
        }

        static void ReorderListPtrs(ListNode head)
        {
           
            if(head.next == null)
                return;        
   
            var tailPtr = head;
        
            /* finding length */
            int length = 0;
            while(tailPtr != null)
            {
                length++; 
                tailPtr = tailPtr.next;
            }
        
            var startPtr = head.next;
            head.next = null;
            length--;
        
            var orgHeadPtr = head;
        
    
            while(length > 0)
            {
                tailPtr = startPtr;
            
                for(int i = 0; i < length - 1; i++)
                    tailPtr = tailPtr.next;
            
                orgHeadPtr.next = new ListNode(tailPtr.val);
            
                if(length == 1)
                    break;
            
                orgHeadPtr.next.next = new ListNode(startPtr.val);
                orgHeadPtr = orgHeadPtr.next.next;
           
                startPtr = startPtr.next;
                length -= 2;
            }

            var x = 2;

        }

        static void ReorderList(ListNode head)
        {
            if(head.next == null)
                return;        
            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            ListNode p1 = head;
            ListNode p2 = slow;
            Queue<int> queue = new Queue<int>();
            Stack<int> stack = new Stack<int>();    

            while (p1 != slow)
            {
                queue.Enqueue(p1.val);
                p1 = p1.next;    
            }
        
            
            while (p2 != null)
            {
                stack.Push(p2.val);
                p2 = p2.next;    
            }
        
            queue.Dequeue();       
            while(queue.Count > 0)
            {
                var popped = stack.Pop();
                head.next = new ListNode(popped);
                var dequeued = queue.Dequeue();
                head.next.next = new ListNode(dequeued);
                head = head.next.next;
            }     
            head.next = new ListNode(stack.Pop());
            if(stack.Count > 0)
                head.next.next = new ListNode(stack.Pop());

        }
    }
}
