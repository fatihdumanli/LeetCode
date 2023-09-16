namespace ii;
class Program
{
    static void Main(string[] args)
    {
        var nums = new int[] { 3, 4, 5, 6, 7, 0, 1, 2 };
        var r = FindMin(nums);

        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/submissions/
    static int FindMin(int[] nums)
    {
        if (nums.Length == 2)
            return Math.Min(nums[0], nums[1]);

        return FindMin(nums, 0, nums.Length - 1, nums[0]);
    }

    /// <summary>
    /// The intuition here is to guess where the miniumum element could be by 
    /// Splitting the entire array into two parts after getting the mid by the formula (start + end) / 2.
    /// [0, mid] and [mid, end]
    /// Either left or right part HAS TO BE sorted.
    /// If left part is sorted, that means the minimum element we could get is nums[start].
    /// If the right part is sorted, we know that mid is the minimum (because it is the initial point of the right array.)
    /// By recursively running this algorithm (which is actually binary search); we finally come to a point 
    /// Where there are no elements to process and we should've come across the minimum.
    /// Since it's technically binary search, it costs O(log n).
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="min"></param>
    /// <returns></returns>
    static int FindMin(int[] nums, int start, int end, int min)
    {
        if (start == end)
        {
            min = Math.Min(min, nums[start]);
            return min;
        }

        var mid = (start + end) / 2;

        // Left part is sorted - RECORD the most left as MIN as search RIGHT
        // Here we included equals...
        // Imagine array [5,1] and start = 0 end = 1
        // If we divide an odd number by 2  (0 + 1) / = 0,
        // It always deviates to the left. (floor)
        // If the minimum element happens to be on the right, we shouldn't miss that. 
        // Therefore, when there are only two elements to process, we always search the RIGHT part of the array.
        if (nums[start] <= nums[mid])
        {
            min = Math.Min(min, nums[start]);
            return FindMin(nums, mid + 1, end, min);
        }

        // Left part is NOT sorted - RECORD the mid as MIN and search LEFT 
        else
        {
            min = Math.Min(min, nums[mid]);
            return FindMin(nums, start, mid, min);
        }
    }
}
