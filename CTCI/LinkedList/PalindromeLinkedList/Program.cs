using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace PalindromeLinkedList
{
    class PalindromeWrapper
    {
        public ListNode node { get; set; }
        public bool isPalindrome { get; set; } = true;
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            //abba
            var l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(2);
            l1.next.next.next = new ListNode(1);

            //aba
            var l2 = new ListNode('a');
            l2.next = new ListNode('b');
            l2.next.next = new ListNode('a');

            var result = IsPalindrome(l1);
            Console.WriteLine(result);
        }


        
        static bool IsPalindrome(ListNode node)
        {
            var length = GetLength(node);
            var result = IsPalindrome(node, length);
            
            return result.isPalindrome;
            //var palindromeWrapper =  IsPalindrome(node, node);
            //return palindromeWrapper.isPalindrome;
        }

        // 1 -> null
        // 1 -> 2 -> 3 -> 4 -> 1 -> null
        // 1 -> 2 -> 1 -> null
        // 1 -> 2 -> 2 -> 1 -> null
        //Recursive approach 2: Traversing up to the middle element then start backtracking.
        static PalindromeWrapper IsPalindrome(ListNode head, int length)
        {
            if(length == 0 || head.next == null)
                return new PalindromeWrapper() { node = head, isPalindrome = true };
            if(length == 1)
                return new PalindromeWrapper() { node = head.next, isPalindrome = true };

            var result = IsPalindrome(head.next, length - 2);
        
            if(result.node.val != head.val)
                result.isPalindrome = false;
        
            result.node = result.node.next;  
            return result;
        }
        static int GetLength(ListNode head)
        {
            int length = 0;
            while (head != null)
            {
                length++;
                head = head.next;
            }
            return length;
        }
      

        //Recursive approach 1 (Going all the way down to the last node).
        static PalindromeWrapper IsPalindrome(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return new PalindromeWrapper() { isPalindrome = true, node = l2 };

            var wrapper = IsPalindrome(l1.next, l2);

            if (l1.val != wrapper.node.val)
                wrapper.isPalindrome = false;

            wrapper.node = wrapper.node.next;
            
            return wrapper;
        }
    }
}
