Console.WriteLine("Hello, World!");



// https://leetcode.com/problems/move-zeroes/
var arr = new int[] {0,1,0,3,12};

// 1,3,12,0,0
MoveZeroes(arr);

void MoveZeroes(int[] nums) 
 {
    int ptr = 0;

    while (ptr < nums.Length) {
        if (nums[ptr] != 0) {
            ptr++;
            continue;
        }

        ShiftLeft(nums, ptr);
        nums[nums.Length - 1] = 0;
    }
}

void ShiftLeft(int[] nums, int from)
{
    for(int i = from; i < nums.Length - 1; i++) {
        nums[i] = nums[i + 1];
    }
}

void PrintArray(int[] nums)
{
    for(int i = 0; i < nums.Length; i++) 
    {
        Console.Write($"{nums[i]} ");
    }
}

