﻿//https://leetcode.com/problems/min-max-game/

var nums = new int[]
{
    1,3,5,2,4,8,2,2
};

var result = MinMaxGame(nums);
Console.WriteLine(result);

int MinMaxGame(int[] nums)
{
    if(nums.Length == 1)
        return nums[0];

    var newNums = new int[nums.Length / 2];

    for(int i = 0; i < newNums.Length; i++)
    {
        if(i % 2 == 0)
        {
            newNums[i] = Math.Min(nums[2 * i], nums[(2 * i) + 1]);
        }
        else
        {
            newNums[i] = Math.Max(nums[2 * i], nums[(2 * i) + 1]);
        }
    }

    return MinMaxGame(newNums);
}