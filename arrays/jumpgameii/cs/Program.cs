// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var nums = new int[] { 2, 3, 1, 1, 4 };
var r = Jump(nums);
Console.WriteLine(r);


int Jump(int[] nums)
{
    var min = 0;
    Helper(nums, 0, 0);
    return min;
}

void Helper(int[] nums, int current, int steps)
{
    if (current >= nums.Length)
        return;

    if (nums[current] == 0)
        return;

    var max = nums[current];

    for (int i = 1; i <= max; i++)
    {
        Helper(nums, current + i, steps++);
    }
}
