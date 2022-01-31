using System;
using Common;

namespace InvertBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var treeNode = new TreeNode(4);
            treeNode.left = new TreeNode(2);
            treeNode.left.left = new TreeNode(1);
            treeNode.left.right = new TreeNode(3);

            treeNode.right = new TreeNode(7);
            treeNode.right.left = new TreeNode(6);
            treeNode.right.right = new TreeNode(9);


            InvertTheTree(treeNode);
            Console.WriteLine("Hello World!");
        }

        /*
         *                4
         *            /      \
         *           2        7
         *          / \      / \
         *         1  3     6   9
         *
         *
         *
         *
         *
         * 
         */
        private static void InvertTheTree(TreeNode treeNode)
        {
            if (treeNode == null)
                return;

            TreeNode temp;
            
            var left = treeNode.left;
            var right = treeNode.right;

            temp = treeNode.left;
            treeNode.left = treeNode.right;
            treeNode.right = temp;
            
            InvertTheTree(treeNode.left);
            InvertTheTree(treeNode.right);
            
        }
    }
}