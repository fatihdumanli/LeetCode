var nums = new int[] { 7 };
var target = 7;

var r = MinSubArrayLen(target, nums);
Console.WriteLine(r);

// https://leetcode.com/problems/minimum-size-subarray-sum/
int MinSubArrayLen(int target, int[] nums)
{
    var left = 0;
    var right = 0;
    var sum = nums[0];
    var min = Int32.MaxValue;

    while(right < nums.Length)
    {
        if(sum >= target)
        {
            min = Math.Min(min, right - left + 1);

            // shrink
            sum -= nums[left];
            left++;
        }
        else
        {
            // expand
            right++;
            
            // only if there's space
            if(right < nums.Length)
                sum += nums[right];
        }
    }

    return min == Int32.MaxValue ? 0 : min;
}