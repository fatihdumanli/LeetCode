using System;
using System.Collections.Generic;
using Common;

namespace Successor
{ 
    class Program
    {
        static void Main(string[] args)
        {
            var root = new LinkedTreeNode(15);
            root.left = new LinkedTreeNode(10);
            root.left.parent = root;
            root.left.left = new LinkedTreeNode(9);
            root.left.left.parent = root.left;
            root.left.right = new LinkedTreeNode(11);
            root.left.right.parent = root.left;
            root.left.right.right = new LinkedTreeNode(12);
            root.left.right.right.parent = root.left.right;


            root.right = new LinkedTreeNode(20);
            root.right.parent = root;
            root.right.left = new LinkedTreeNode(17);
            root.right.left.parent = root.right;
            root.right.right = new LinkedTreeNode(25);
            root.right.right.parent = root.right;
            root.right.right.left = new LinkedTreeNode(23);
            root.right.right.left.parent = root.right.right;
            root.right.right.left.right = new LinkedTreeNode(24);
            root.right.right.left.right.parent = root.right.right.left;
            
            var result = FindSuccessor(root, 9);
            result = FindSuccessor(root, 15);
            result = FindSuccessor(root, 10);
            result = FindSuccessor(root, 11);
            result = FindSuccessor(root, 12);
            result = FindSuccessor(root, 20);
            result = FindSuccessor(root, 17);
            result = FindSuccessor(root, 25);
            result = FindSuccessor(root, 23);
            result = FindSuccessor(root, 24);


        }

        static LinkedTreeNode FindSuccessor(LinkedTreeNode root, int val)
        {
            var node = FindNode(root, val);

            if (node.right != null)
            {
                //Find leftmost node in the right subtree.
                return LeftMost(node.right);
            }

            //go up to the parent until we discover a parent with a greater value.
            var ptr = node.parent;

            while (ptr.val < node.val)
            {
                ptr = ptr.parent;
                if (ptr == null) return null;
            }

            return ptr;
        }

        static LinkedTreeNode LeftMost(LinkedTreeNode root)
        {
            if(root == null) return null;
            while (root.left != null)
                root = root.left;
            return root;
        }

        static LinkedTreeNode FindNode(LinkedTreeNode root, int val)
        {
            if (root == null) return null;
            var left = FindNode(root.left, val);
            if (left != null) return left;
            if (root.val == val) return root;
            var right = FindNode(root.right, val);
            if (right != null) return right;
            return null;
        }
    }
}
