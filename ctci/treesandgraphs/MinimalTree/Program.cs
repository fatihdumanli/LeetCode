using System;
using Common;

namespace MinimalTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[]
            {
                10,11,12, 13,14
            };

            var result = MinimalTree(arr);
            Console.WriteLine("Hello World!");
        }

        static TreeNode MinimalTree(int[] nums)
        {
            return CreateMinimalTree(nums, 0, nums.Length - 1);
        }

        static TreeNode CreateMinimalTree(int[] nums, int start, int end)
        {
            if (end < start)
                return null;

            var mid = (start + end) / 2;
            var node = new TreeNode(nums[mid]);
            node.left = CreateMinimalTree(nums, start, mid - 1);
            node.right = CreateMinimalTree(nums, mid + 1, end);

            return node;
        }
    }
    
}
