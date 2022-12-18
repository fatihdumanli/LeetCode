//var houses = new int[] { 1, 2, 3, 1 };
var houses = new int[] { 2, 7, 9, 3, 1 };
var r = Rob(houses);
Console.WriteLine(r);


static int Rob(int[] nums)
{
    var dp = new int[nums.Length];

    for (int i = 0; i < dp.Length; i++)
        dp[i] = -1;

    return Helper(nums, 0, dp);
}

static int Helper(int[] nums, int start, int[] dp)
{
    if (start >= dp.Length)
        return 0;

    if (start == nums.Length - 1)
        return nums[start];

    if (dp[start] != -1)
        return dp[start];

    for (int i = start; i < nums.Length; i++)
    {
        dp[i] = Math.Max(nums[i] + Helper(nums, i + 2, dp), Helper(nums, i + 1, dp));
    }

    return dp[start];
}

