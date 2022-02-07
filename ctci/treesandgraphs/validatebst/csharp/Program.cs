using System;
using Common;

namespace ValidateBST
{
    public class ValidBSTWrapper
    {
        public int min = Int32.MaxValue;
        public int max = Int32.MinValue;
        public bool isValid;
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var treeNode = new TreeNode(2);
            treeNode.left = new TreeNode(1);
            treeNode.right = new TreeNode(3);

            var isValid = IsValidBST(treeNode);
        }
        
        static bool IsValidBST(TreeNode root) {
            return IsValidHelper(root, null, null);
        }
        
        static bool IsValidHelper(TreeNode root, int? min, int? max)
        {
            if(root == null) return true;  
            var leftResult = IsValidHelper(root.left, min, root.val);
            if(!leftResult) return false;
            if(root.val >= max || root.val <= min) return false;
            var rightResult = IsValidHelper(root.right, root.val, max);
            if(!rightResult) return false;
            return true;        
        }
    }
}
