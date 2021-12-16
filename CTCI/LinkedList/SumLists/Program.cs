using System;
using System.Collections.Generic;
using Common;

namespace SumLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var l1 = new ListNode(6);
            l1.next = new ListNode(1);
            l1.next.next = new ListNode(7);
            
            
            var l2 = new ListNode(2);
            l2.next = new ListNode(9);
            l2.next.next = new ListNode(5);

            var sum = SumListsReverseIterative(l1, l2);
            sum = SumListsReverseRecursive(l1, l2);
            sum = SumListsForward(l1, l2);
        }

        private static ListNode newHead = new ListNode(0);
        static ListNode SumListsForward(ListNode l1, ListNode l2)
        {
            SumListsForwardHelper(l1, l2);
            return newHead;
        }

        static int SumListsForwardHelper(ListNode l1, ListNode l2, int carry = 0)
        {
            if (l1 == null && l2 == null)
                return carry;

            carry = SumListsForwardHelper(l1?.next, l2?.next, carry);

            var l1Value = l1?.val ?? 0;
            var l2Value = l2?.val ?? 0;

            newHead.next = new ListNode((l1Value + l2Value + carry) % 10);
            newHead = newHead.next;

            return (l1Value + l2Value) / 10;
        }
        
        
        
        
        
        
        static ListNode SumListsReverseRecursive(ListNode l1, ListNode l2, int carry = 0)
        {
            if(l1 == null && l2 == null && carry == 0)
                return null;
        
            var l1Value = l1 == null ? 0 : l1.val;
            var l2Value = l2 == null ? 0 : l2.val;
        
            var sum = l1Value + l2Value + carry;       
        
            return new ListNode(sum%10) { next = SumListsReverseRecursive(l1?.next, l2?.next, sum / 10) };
        }
        static ListNode SumListsReverseIterative(ListNode l1, ListNode l2)
        {
            int carry = 0;
        
            ListNode newHead = new ListNode();
            ListNode ptr = newHead;
        
        
            while(l1 != null || l2 != null)
            {
                var l1Val = l1?.val ?? 0;
                var l2Val = l2?.val ?? 0;
                var sum = (l1Val + l2Val + carry) % 10;     
                ptr.next = new ListNode(sum);
                ptr = ptr.next;
                carry = ((l1?.val ?? 0) + (l2?.val ?? 0) + carry) / 10;
                l1 = l1?.next;
                l2 = l2?.next;
            }
        
            if(carry > 0)
                ptr.next = new ListNode(carry);
        
            return newHead.next;
        }
    }
}
