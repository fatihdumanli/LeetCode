namespace ii;
class Program
{
    static void Main(string[] args)
    {
        var nums = new int[]   { 4,5,6,7,0,1,2};
        var r = Search(nums, 4);
        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/search-in-rotated-sorted-array
    static int Search(int[] nums, int target)
    {
        return Search(nums, 0, nums.Length - 1, target);
    }
    
    static int Search(int[] nums, int start, int end, int target)
    {
        var mid = (start + end) / 2;
        
        if(nums[mid] == target)
            return mid;

        if(start == end)
            return -1;
        
        // left part is sorted
        if(nums[start] <= nums[mid])
        {
            if(nums[start] > target)
                return Search(nums, mid + 1, end, target);
            
            if(nums[mid] < target)
                return Search(nums, mid + 1, end, target);
            
            return Search(nums, start, mid, target);
        }
        
        // right part is sorted
        else
        {
            if(target < nums[mid])
                return Search(nums, start, mid - 1, target);
            
            if(target > nums[end])
                return Search(nums, start, mid - 1, target);
            
            return Search(nums, mid, end, target);
        }
    }
}
