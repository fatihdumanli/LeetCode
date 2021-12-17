using System;
using System.Collections.Generic;
using Common;

namespace SumLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(3);
            l1.next.next.next = new ListNode(4);
            
            var l2 = new ListNode(5);
            l2.next = new ListNode(6);
            l2.next.next = new ListNode(7);

            //var sum = SumListsReverseIterative(l1, l2);
            //sum = SumListsReverseRecursive(l1, l2);
            //sum = SumListsForward(l1, l2);
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
