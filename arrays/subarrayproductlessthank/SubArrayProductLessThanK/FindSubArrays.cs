namespace SubArrayProductLessThanKLib;

public class SubArrayProductLessThanK
{
    public int NumSubarrayProductLessThanK(int[] nums, int k)
    {
        var total = 0;

        var left = 0;
        var right = 0;
        var product = 1;

        // 10, 5, 2, 6
        while (right < nums.Length)
        {
            product *= nums[right];

            if (product < k)
            {
                total++;
                right++;
            }
            else
            {
                left++;
                right = left;
                product = 1;
            }

            if (right >= nums.Length && left < nums.Length)
            {
                left++;
                right = left;
                product = 1;
            }
        }

        return total;
    }
}
