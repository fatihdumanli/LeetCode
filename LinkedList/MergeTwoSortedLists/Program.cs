using System;
using Common;

namespace MergeTwoSortedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            //21. Merge Two Sorted Lists
            //https://leetcode.com/problems/merge-two-sorted-lists/
            var listNode1 = new ListNode(1);
            listNode1.next = new ListNode(2);
            listNode1.next.next = new ListNode(4);

            var listNode2 = new ListNode(1);
            listNode2.next = new ListNode(3);
            listNode2.next.next = new ListNode(4);
            
            var newHead = MergeTwoListsRecursive(listNode1, listNode2);
        }

        static ListNode MergeTwoListsRecursive(ListNode list1, ListNode list2)
        {
            if (list1 == null)
                return list2;

            if (list2 == null)
                return list1;

            if (list1 != null && list2 != null)
                return list1.val < list2.val ? list1 : list2;
            
            list1.next = MergeTwoListsRecursive(list1.next, list2.next);

            return list1.val < list2.val ? list1 : list2;
        }
        

        public static ListNode InsertBefore(ListNode node, int value)
        {
            if(node == null)
                return new ListNode(value);
        
            var newHead = new ListNode(value);
            newHead.next = node;
            return newHead;
        }

        static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode newHead = new ListNode();

            ListNode newPtr = newHead;
            
            while (l1 != null || l2 != null)
            {
                newPtr.next = new ListNode();
                newPtr = newPtr.next;
                
                if (l1 == null)
                {
                    newPtr.val = l2.val;
                    l2 = l2.next;
                }
                
                else if (l2 == null)
                {
                    newPtr.val = l1.val;
                    l1 = l1.next;
                }
                
                else if (l1.val == l2.val)
                {
                    newPtr.val = l1.val;
                    l1 = l1.next;
                }

                else if (l1.val < l2.val)
                {
                    newPtr.val = l1.val;
                    l1 = l1.next;
                }
                
                else if (l2.val < l1.val)
                {
                    newPtr.val = l2.val;
                    l2 = l2.next;
                }
            }

            return newHead.next;
        }
        
    }
}