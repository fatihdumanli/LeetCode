using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace IsSubTreeNs
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode(3);
            root.left = new TreeNode(1);

            var subRoot = new TreeNode(3);
            var result = IsSubtree(root, subRoot);
        }

        static bool IsSubtree(TreeNode root, TreeNode subRoot)
        {  
            var matchingNodes = new List<TreeNode>();
            FindNodes(root, subRoot, matchingNodes);
        
            foreach(var node in matchingNodes)
                if(IsSame(node, subRoot))
                    return true;
            
            return false;

        }
        
        static bool IsSame(TreeNode root, TreeNode subRoot)
        {
            if(root == null && subRoot == null)
                return true;
            if(root == null || subRoot == null)
                return false;
        
            if(root.val != subRoot.val)
                return false;
    
            var left = IsSame(root.left, subRoot.left);
            var right = IsSame(root.right, subRoot.right);
            return left && right;
        }


        static void FindNodes(TreeNode root, TreeNode subRoot, List<TreeNode> results)
        {
            if(root == null)
                return;
            if(root.val == subRoot.val)
                results.Add(root);
            FindNodes(root.left, subRoot, results);
            FindNodes(root.right, subRoot, results);
        }
    }
}
