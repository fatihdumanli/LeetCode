// var nums = new int[] { 0, 1, 1, 1, 0, 1, 1, 0, 1 };
// var nums = new int[] { 1, 1, 1 };
var nums = new int[] { 1, 1, 0, 1 };
var r = LongestSubarray(nums);
Console.WriteLine(r);

// https://leetcode.com/problems/longest-subarray-of-1s-after-deleting-one-element/
int LongestSubarray(int[] nums)
{
    var left = 0;
    var right = 0;

    var numOfRoomsForZeros = 1;
    var max = 0;
    
    while(right < nums.Length)
    {
        if(nums[right] == 0)
            numOfRoomsForZeros--;
        
        if(numOfRoomsForZeros == -1)
        {
            if(nums[left] == 0)
            {
                left++;
                numOfRoomsForZeros++;
            }
            
            else
            {
                while(nums[left] == 1)
                    left++;

                // here it's pointing to zero, we gotta move it once more
                left++;
                numOfRoomsForZeros++;
            }
        }

        // it's valid window here
        max = Math.Max(max, right - left + 1);

        //expand the window
        right++;
    }

    return max - 1;
}


