using System;
using Common;

namespace CheckBalanced
{
    class Program
    {
        static void Main(string[] args)
        {
            var treeNode = new TreeNode(5);
            treeNode.left = new TreeNode(4);
            treeNode.left.left = new TreeNode(3);
            treeNode.left.left.left = new TreeNode(2);
            treeNode.left.right = new TreeNode(6);
            treeNode.left.right.right = new TreeNode(7);
            treeNode.left.right.right.left = new TreeNode(6);

            treeNode.right = new TreeNode(7);
            treeNode.right.right = new TreeNode(9);
            treeNode.right.right.right = new TreeNode(10);

            var result = CheckBalanced(treeNode);
            
            Console.WriteLine("Hello World!");
        }

        static bool CheckBalanced(TreeNode root)
        {
            return GetHeight(root) != -99;
        }

        static int GetHeight(TreeNode root)
        {
            if (root == null) return 0;
            var leftHeight = GetHeight(root.left);
            if (leftHeight == -99) return -99;
            var rightHeight = GetHeight(root.right);
            if (rightHeight == -99) return -99;
            if (Math.Abs(leftHeight - rightHeight) > 1) return -99;
            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }
}
