
var nums = new int[] { 1, 3 };
var r = SearchInsert(nums, 2);

Console.WriteLine(r);

// https://leetcode.com/problems/search-insert-position
int SearchInsert(int[] nums, int target)
{
    return BinarySearch(nums, target, 0, nums.Length - 1, (0 + nums.Length - 1) / 2);
}

int BinarySearch(int[] nums, int target, int start, int end, int prevMid)
{
    if (start >= nums.Length)
    {
        return nums.Length;
    }

    if (start > end)
    {
        if(target < nums[prevMid])
        {
            return prevMid;
        }

        return prevMid + 1;
    }

    var mid = (start + end) / 2;

    if (target == nums[mid])
        return mid;

    else if (target < nums[mid])
    {
        return BinarySearch(nums, target, start, mid - 1, mid);
    }

    return BinarySearch(nums, target, start + 1, end, mid);
}

