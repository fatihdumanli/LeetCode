using System;
using Common;

namespace IsSymmetricNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            /* PREPARE THE TREE */
            var root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.left.left = new TreeNode(3);
            root.left.right = new TreeNode(4);

            root.right = new TreeNode(2);
            root.right.left = new TreeNode(4);
            root.right.right = new TreeNode(3);
            /* PREPARE THE TREE */


            var isSymmetric = IsSymmetric(root);

            Console.WriteLine("Hello World!");
        }

        static bool IsSymmetric(TreeNode root)
        {
            if (root == null)
                return true;
            
            return IsSymmetric(root.left, root.right);
        }

        static bool IsSymmetric(TreeNode left, TreeNode right)
        {
            if (left == null && right == null)
                return true;

            if (left == null || right == null)
                return false;

            if (left.val != right.val)
                return false;
            
            
            return IsSymmetric(left.left, right.right) && IsSymmetric(left.right, right.left);
            
        }
    }
}