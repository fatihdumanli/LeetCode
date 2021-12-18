using System;
using Common;

namespace ReorderList
{
    public class ReorderWrapper 
    {
        public ListNode originalHead;
        public ListNode tailPtr;
        public ListNode headPtr;
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);

            
            ReorderList(head);
            Console.WriteLine("Hello World!");
        }
        
        static void ReorderList(ListNode head) {
            var wrapper = new ReorderWrapper() {
                originalHead = head,
                headPtr = head
            };
        
            var tailPtr = head;
        
            var result = ReorderHelper(tailPtr, wrapper);
        }
        
        static ReorderWrapper ReorderHelper(ListNode tailPtr, ReorderWrapper wrapper)
        {
            if (tailPtr.next == null)
            {
                
            }
        
            var result = ReorderHelper(tailPtr.next, wrapper);
        
            var temp = wrapper.headPtr.next;
            wrapper.headPtr.next = tailPtr;
            wrapper.headPtr.next.next = temp;
            wrapper.headPtr = wrapper.headPtr.next.next;
        
        
            return wrapper;
        }
    }
}
