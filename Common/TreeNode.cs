﻿using System;

namespace Common
{
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
