using System;
using Common;

namespace SumListsForward
{
    class PartialSum
    {
        public ListNode sum { get; set; }
        public int carry { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var l1 = new ListNode(4);
            l1.next = new ListNode(2);

            var l2 = new ListNode(3);
            l2.next = new ListNode(8);
            
            var result = AddTwoLists(l1, l2);
        }

        private static ListNode AddTwoLists(ListNode l1, ListNode l2)
        {
            var len1 = GetLength(l1);
            var len2 = GetLength(l2);

            if (len1 < len2)
                l1 = PadRight(l1, len2 - len1);
            else if (len2 < len1)
                l2 = PadRight(l2, len1 - len2);

            var partialSum = AddListHelper(l1, l2);

            if (partialSum.carry > 0)
                partialSum.sum = InsertBefore(partialSum.sum, partialSum.carry);
            
            return partialSum.sum;
        }

        private static ListNode resultList = null;
        private static PartialSum AddListHelper(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
                return new PartialSum() { carry = 0, sum = null };
            
            var partialSum = AddListHelper(l1.next, l2.next);
            var sum = l1.val + l2.val + partialSum.carry;
            partialSum.sum = InsertBefore(partialSum.sum, sum % 10);
            partialSum.carry = sum / 10;
            return partialSum;
        }
        
        
        
        
        private static ListNode PadRight(ListNode list, int n)
        {
            for (int i = 0; i < n; i++)
            {
                list = InsertBefore(list, 0);
            }

            return list;
        }



        private static ListNode InsertBefore(ListNode list, int value)
        {
            var node = new ListNode(value);
            if (list == null)
                return node;
            node.next = list;
            return node;
        }


        private static int GetLength(ListNode listNode)
        {
            int length = 0;

            while (listNode != null)
            {
                length++;
                listNode = listNode.next;
            }

            return length;
        }

    }
}
