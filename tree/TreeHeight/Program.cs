using System;
using Common;

namespace TreeHeight
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
            
            var result = MaxDepth(treeNode);
            Console.WriteLine(result);
        }

        private static int MaxDepth(TreeNode root)
        {
            if(root == null)
                return 0;    
        
            var leftDepth = MaxDepth(root.left);
            var rightDepth = MaxDepth(root.right);
        
            return Math.Max(leftDepth, rightDepth) + 1;
        }
    }
}