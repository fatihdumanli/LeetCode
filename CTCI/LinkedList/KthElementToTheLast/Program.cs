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
           // var res = GetKthElementToTheTailIterative(head, 1);
            Console.WriteLine("Hello World!");
        }

        static ListNode GetKthElementToTheTailIterative(ListNode head, int k)
        {
            int runnerSteps = 0;
            int currentSteps = 0;
            ListNode current = head;
            ListNode runner = head;
            int stepsToTake = 0;
            
            while (current != null)
            {
                if (runner == null)
                {
                    if (runnerSteps % 2 == 0)
                    {
                        currentSteps++;
                        current = current.next;
                    }

                    var pos = runnerSteps - k;
                    stepsToTake = pos - currentSteps;
                    
                    while (stepsToTake > 0)
                    {
                        current = current.next;
                        stepsToTake--;
                    }

                    return current;
                }

                if (runnerSteps % 2 == 0 && runnerSteps > 0)
                {                    
                    current = current.next;
                    currentSteps++;
                }
                
                runner = runner.next;
                runnerSteps++;
            }

            return null;
        }
        static ListNode GetKthElementToTheTail(ListNode head, int k)
        {
            var index = new Index();
            index.val = 0;
            
            return GetKthElementToTheTail(head, k, index);
        }

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
