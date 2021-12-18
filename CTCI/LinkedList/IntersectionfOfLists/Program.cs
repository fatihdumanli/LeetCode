using System;
using System.Collections.Generic;
using Common;

namespace IntersectionfOfLists
{
    class IntersectionResult
    {
        public bool result = true;
        public int aLength = 0;
        public int bLenght = 0;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var headA = new ListNode(2);
            headA.next = new ListNode(2);

            var headB = new ListNode(2);
            headB.next = new ListNode(2);

            var headC = new ListNode(4);
            headC.next = new ListNode(5);
            headC.next.next = new ListNode(4);

            headA.next = headC;
            headB.next = headC;

            var result = GetIntersectionNode(headA, headB);

            Console.WriteLine("Hello World!");
        }


        private static IntersectionResult CheckTailsAreTheSame(ListNode headA, ListNode headB)
        {
            var result = new IntersectionResult();
            
            while(headA.next != null || headB.next != null)
            {
                if (headA.next != null)
                    result.aLength++;

                if (headB.next != null)
                    result.bLenght++;

                if (headA.next != null)
                    headA = headA.next;

                if (headB.next != null)
                    headB = headB.next;

                if (headA.next == null && headB.next == null && headA != headB)
                {
                    result.result = false;
                    return result;
                }
                
            }

            return result;
        }
        
        
        private static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var result = CheckTailsAreTheSame(headA, headB);

            if (!result.result)
                return null;
            
            var shorter = result.aLength < result.bLenght ? headA : headB;
            var longer = result.bLenght > result.aLength ? headB : headA;

            longer = GetKthNode(longer, Math.Abs(result.aLength - result.bLenght));
            
            while (shorter != longer)
            {
                shorter = shorter.next;
                longer = longer.next;
            }
            
            return shorter;
        }
        private static ListNode GetKthNode(ListNode node, int k)
        {
            while (k-- > 0)
                node = node.next;
            return node;
        }
        
    }
}
