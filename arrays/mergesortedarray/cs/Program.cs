using System.Data;

namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var nums1 = new int[] { 1, 7, 8, 9, 14, 0, 0, 0 };
        var m = 5;

        var nums2 = new int[] { 15, 15, 17 };
        var n = 3;

        Merge(nums1, m, nums2, n);

        Console.WriteLine("hello world");
    }

    // https://leetcode.com/problems/merge-sorted-array
    public static void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        var tail1 = m - 1;
        var tail2 = n - 1;
        var finalPtr = m + n - 1;

        while (tail1 >= 0 && tail2 >= 0)
        {
            if (nums1[tail1] > nums2[tail2])
            {
                nums1[finalPtr--] = nums1[tail1--];
            }
            else
            {
                nums1[finalPtr--] = nums2[tail2--];
            }
        }

        // we could've consumed all numbers in nums1
        // check if there's any left in nums2
        while (tail2 >= 0)
            nums1[finalPtr--] = nums2[tail2--];
    }
}
