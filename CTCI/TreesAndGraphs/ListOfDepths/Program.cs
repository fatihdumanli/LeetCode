using System;
using System.Collections.Generic;
using Common;

namespace ListOfDepths
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode(15);
            root.left = new TreeNode(10);
            root.left.left = new TreeNode(9);
            root.left.left.left = new TreeNode(5);
            root.left.right = new TreeNode(11);
            root.left.right.left = new TreeNode(5);
            root.left.right.right = new TreeNode(2);
            
            root.right = new TreeNode(13);
            root.right.right = new TreeNode(14);
            root.right.left = new TreeNode(12);
            root.right.left.left = new TreeNode(9);
            root.right.right.right = new TreeNode(16);
            root.right.right.left = new TreeNode(6);
            
            var result = ListOfDepths(root);

            result = ListOfDepthsDFS(root);
            
            Console.WriteLine("Hello World!");
        }


        static IList<LinkedList<TreeNode>> ListOfDepthsDFS(TreeNode root)
        {
            var result = new List<LinkedList<TreeNode>>();
            ListOfDepthsDFS(root, result);
            return result;
        }

        static void ListOfDepthsDFS(TreeNode root, IList<LinkedList<TreeNode>> result, int level = 0)
        {
            if (root == null)
                return;

            if (result.Count < level + 1)
                result.Add(new LinkedList<TreeNode>());

            result[level].AddLast(root);
            ListOfDepthsDFS(root.left, result, level + 1);
            ListOfDepthsDFS(root.right, result, level + 1);
        }
        
        
        static IList<LinkedList<TreeNode>> ListOfDepths(TreeNode root)
        {
            var result = new List<LinkedList<TreeNode>>();
            if (root == null)
                return result;
            
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            
            var first = new LinkedList<TreeNode>();
            first.AddLast(root);
            result.Add(first);

            var head = new LinkedList<TreeNode>();
            
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if(node.left != null)
                    head.AddLast(node.left);
                if(node.right != null)
                    head.AddLast(node.right);

                if (queue.Count == 0)
                {
                    foreach(var item in head)
                        queue.Enqueue(item);
                    if(head.Count > 0)
                        result.Add(head);
                    head = new LinkedList<TreeNode>();
                }
            }

            return result;
        }
    }
}
 