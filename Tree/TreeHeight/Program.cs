using System;
using Common;

namespace TreeHeight
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode(3);
            root.left = new TreeNode(9);
            
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);

            var result = MaxDepth(root);
            Console.WriteLine(result);
        }

        private static int MaxDepth(TreeNode root)
        {
            if(root == null)
                return 0;    
        
            var leftDepth = MaxDepth(root.left) + 1;
            var rightDepth = MaxDepth(root.right) + 1;
        
            return Math.Max(leftDepth, rightDepth);
        }
    }
}