using System;
using Common;

namespace KthElementToTheLast
{
    class Index
    {
        public int val = 0;
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next = new ListNode(6);
            head.next.next.next.next.next.next = new ListNode(7);

            ListNode kthElement = null;
            var result = GetKthElementToTheTail(head, 3);
            result = GetKthElementToTheTailIterative(head, 9);
            Console.WriteLine("Hello World!");
        }

        //Time complexity: O(N)
        static ListNode GetKthElementToTheTailIterative(ListNode head, int k)
        {
            if (head == null)
                return null;
            
            var first = head;
            var runner = head;
            for (int i = 0; i < k; i++)
            {
                runner = runner.next;
                
                if (runner == null)
                    throw new Exception("k is out of range");
            }

            while (runner != null)
            {
                runner = runner.next;
                first = first.next;
            }

            return first;
        }
        static ListNode GetKthElementToTheTail(ListNode head, int k)
        {
            var index = new Index();
            index.val = 0;
            
            return GetKthElementToTheTail(head, k, index);
        }

        /*
         * Time complexity: O(N)
         * Space complexity: O(N)
         */
        static ListNode GetKthElementToTheTail(ListNode head, int k, Index index)
        {
            if (head == null)
                return null;

            var node = GetKthElementToTheTail(head.next, k, index);

            index.val = index.val + 1;
            if (index.val == k)
                return head;

            return node;
        }

    }
}
