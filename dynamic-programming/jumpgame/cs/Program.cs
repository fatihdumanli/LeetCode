var nums = new int[] { 2, 0, 0 };
var r = CanJump(nums);
Console.WriteLine(r);

bool CanJump(int[] nums)
{
    if (nums.Length == 1)
        return true;

    return DFS(0, nums, new int[nums.Length]);
}

bool DFS(int pos, int[] nums, int[] dp)
{
    if (nums[pos] == 0)
    {
        dp[pos] = -1;
        return false;
    }

    if (pos >= nums.Length - 1)
        return true;

    for (int i = 1; i <= nums[pos]; i++)
    {
        if (pos + i >= nums.Length - 1)
            return true;

        if (dp[pos + i] == -1)
            continue;

        if (DFS(pos + i, nums, dp))
            return true;
    }
    dp[pos] = -1;
    return false;
}