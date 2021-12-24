using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace BSTSequences
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode(5);
            root.left = new TreeNode(3);
            root.left.right = new TreeNode(4);
            root.left.left = new TreeNode(2);
            root.right = new TreeNode(6);
            
            //PrintBSTSequences(root);

            var list1 = new LinkedList<int>();
            list1.AddLast(1);
            list1.AddLast(2);

            var list2 = new LinkedList<int>();
            list2.AddLast(3);
            list2.AddLast(4);

            var results = new List<LinkedList<int>>();
            Weave(list1, list2, new LinkedList<int>(), results);
            Console.WriteLine("Hello World!");
        }

        static void Weave(LinkedList<int> first, LinkedList<int> second, LinkedList<int> prefix, List<LinkedList<int>> results)
        {
            if (first.Count == 0 || second.Count == 0)
            {
                var result = new LinkedList<int>(prefix);
                foreach (var i in first)
                    result.AddLast(i);
                foreach (var i in second)
                    result.AddLast(i);
                results.Add(result);
                return;
            }

            var headFirst = first.First;
            first.RemoveFirst();
            prefix.AddLast(headFirst);
            Weave(first, second, prefix, results);
            prefix.RemoveLast();
            first.AddFirst(headFirst);

            var headSecond = second.First;
            second.RemoveFirst();
            prefix.AddLast(headSecond);
            Weave(first, second, prefix, results);
            prefix.RemoveLast();
            second.AddFirst(headSecond);
        }
        
        static List<ListNode> PrintBSTSequences(TreeNode root)
        {
            var result = new List<ListNode>();

            if (root == null)
            {
                result.Add(new ListNode());
                return result;
            }



            return null;
        }
        
        
    }
}
