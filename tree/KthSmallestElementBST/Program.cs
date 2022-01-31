using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace KthSmallestElementBST
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int KthSmallest(TreeNode root, int k) {
            return Solve(root, ref k);
        }
        
        static int Solve(TreeNode root, ref int k) {
            if(root == null) return Int32.MaxValue;
            var left = Solve(root.left, ref k);
            if(left != Int32.MaxValue)
                return left;
            k--;
            if(k == 0)
                return root.val;
            var right = Solve(root.right, ref k);
            /*
            if(right != Int32.MaxValue)
                return right;
            return Int32.MaxValue;  
            We can shrink these two if statements into 'return right';
            */
            return right;
        }
    }
}   
