using System;
using System.Collections.Generic;
using Common;

namespace LowestCommonAnchestor
{
    public class LCAResult
    {
        public bool isFound = false;
        public TreeNode lca = null;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode(-1);
            root.left = new TreeNode(0);
            root.left.right = new TreeNode(4);
            root.left.left = new TreeNode(-2);
            root.left.left.left = new TreeNode(8);

            root.right = new TreeNode(3);
        }

        private static TreeNode LCA2(TreeNode root)
        {
            var pPath = GetPath(root, new TreeNode(0));
            var qPath = GetPath(root, new TreeNode(4));

            List<int> shorter = pPath;
            List<int> longer = qPath;
            
            if (qPath.Count != pPath.Count)
            {
                shorter = pPath.Count < qPath.Count ? pPath : qPath;
                longer = pPath.Count < qPath.Count ? qPath : pPath;
                var delta = Math.Abs(qPath.Count - pPath.Count);
                shorter = ShiftRight(shorter, delta);
            }


            for (int i = 0; i < shorter.Count; i++)
            {
                if (shorter[i] == longer[i])
                    return new TreeNode(shorter[i]);
            }

            return null;
        }

        private static List<int> ShiftRight(List<int> list, int shiftBy)
        {
            var shifted = new List<int>(list.Count + shiftBy);

            for (int i = 0; i < shiftBy; i++)
                shifted.Add(Int32.MaxValue);

            foreach(var item in list)
                shifted.Add(item);
            
            return shifted;
        }
        
        




        static List<int> GetPath(TreeNode root, TreeNode searchFor)
        {
            if (root == null) return null;
            var left = GetPath(root.left, searchFor);
            var right = GetPath(root.right, searchFor);

            if (root.val == searchFor.val)
                return new List<int>() { root.val };

            if (left == null && right == null)
                return null;

            var listPtr = left ?? right;
            listPtr.Add(root.val);
            return listPtr;
        }



        //Without helper.
        static TreeNode LowestCommonAnchestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if(root == null) return null;
            if(root.val == p.val || root.val == q.val)
                return root;
        
            var leftResult = LowestCommonAncestor(root.left, p, q);
            var rightResult = LowestCommonAncestor(root.right, p, q);
     
            //Check if both are null.
            if(leftResult != null && rightResult != null)
                return root;
        
            //If we manage to get here it'd mean one of them is definitely not null.
            return leftResult == null ? rightResult : leftResult;
        }
        
        
        //With helper
        static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            var result = new LCAResult();
            return LCAHelper(root, p, q).lca;
        }
        
        static LCAResult LCAHelper(TreeNode root, TreeNode q, TreeNode p)
        {
            if (root == null) return new LCAResult();
            var leftResult = LCAHelper(root.left, p, q);
            if (leftResult.lca != null) return leftResult;
            var rightResult = LCAHelper(root.right, p, q);
            //These two lines are more than optimization
            //We should avoid possible overrides with these circuit breakers.
            if (rightResult.lca != null) return rightResult;
            //It doesn't matter which one we return. We're just setting lca convey the result to upper stacks. I've chosen the left one.
            if (leftResult.isFound && rightResult.isFound) { leftResult.lca = root; return leftResult;}
            if ((leftResult.isFound || rightResult.isFound) && (root.val == p.val || root.val == q.val))
            {
                return new LCAResult()
                {
                    isFound = true,
                    lca = root
                };
            }
            if (root.val == p.val || root.val == q.val)
                return new LCAResult() { isFound = true };
            if (leftResult.isFound) return leftResult;
            if (rightResult.isFound) return rightResult;
            //Since both of them are not true, it doesn't matter which one we return.
            //Both of them has isFound property as false.
            return leftResult;
        }
    }
}
