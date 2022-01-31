using System;

namespace Common
{
    public class LinkedTreeNode
    {
        public int val;
        public LinkedTreeNode left;
        public LinkedTreeNode right;
        public LinkedTreeNode parent;
        public LinkedTreeNode(int val)
        {
            this.val = val;
        }
    }
    
    public class TreeNode
    {
        public int val { get; set; }
        public TreeNode left { get; set; }

        public TreeNode right { get; set; }

        public TreeNode(int val)
        {
            this.val = val;
        }
        
        public TreeNode()
        {
        }
    }
}
