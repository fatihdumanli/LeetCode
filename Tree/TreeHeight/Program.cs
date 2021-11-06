using System;
using Common;

namespace TreeHeight
{
    class Program
    {
        static void Main(string[] args)
        {
            var treeNode = new TreeNode(1);
            treeNode.left = new TreeNode(2);
            treeNode.left.left = new TreeNode(4);
            treeNode.left.right = new TreeNode(5);

            treeNode.right = new TreeNode(3);
            treeNode.right.right = new TreeNode(6);
            treeNode.right.right.left = new TreeNode(7);

            var result = GetTreeHeight(treeNode);
            Console.WriteLine(result);
        }

        private static int GetTreeHeight(TreeNode treeNode)
        {
            if (treeNode == null)
                return 0;

            var left = GetTreeHeight(treeNode.left);
            var right = GetTreeHeight(treeNode.right);

            return Math.Max(left, right) + 1;
        }
    }
}