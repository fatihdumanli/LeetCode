package main

import "fmt"

func main() {
    nums := []int{1,3,4,2,2}
    r := findDuplicate(nums)
    fmt.Println(r)
}

// https://leetcode.com/problems/find-the-duplicate-number
func findDuplicate(nums []int) int {

    // The O(N) solution with a hashset is straightforward.
    // The goal is to solve it in linear time without using an extra space.
    // Range will be [1,n] inclusive
    // [1, 3, 4, 2, 2]
    // n = 4
    // Range [1,4]
    // Q: How to prove there must be at least one duplicate number in nums?
    // A: Imagine there's n numbers in the array and each number is within the
    // range [1,n]
    // For an array to comprise of unique integers, there's gotta be a n
    // different numbers
    // N = 3, and each number is within the range [1,3]
    // The only possibility is [1,2,3] - so it's possible
    // However, if there's N + 1 numbers
    // [1,2,3, x] -> we need to replace x with a number...
    // What can we possibly put there - considering the number must be within
    // the range [1, 3]
    // Any number we're likely to put will cause a duplication.
    
    // Since we know that any number will be within the range [1, n] 
    // We can treat the array as visited array 
    // Any number that we encounter must be marked as visited

    // How do we do that? How do we mark a number as visited?
    // Why don't we make it negative, and the next time we can get absolute
    // value.

    // nums[0] = 1 -> nums[1] = -nums[1] (1 is visited)
    // nums[1] = 3 -> nums[3] = -nums[3] (3 is visited)
    // nums[2] = 4 -> nums[4] = -nums[4] (4 is visited)
    // nums[3] = 2 -> nums[2] = -nums[2] (2 is visited)
    // nums[4] = 2 -> nums[2] has already a negative value, we must've already
    // processed it. So the answer is '2'.

    // TC: O(N)
    // SC: O(1)


    for i := 0; i < len(nums); i++ {
        var idx = Abs(nums[i])

        if nums[idx] < 0 {
            return idx
        }

        nums[idx] = -nums[idx]
    }

    return 0
}

func Abs(x int) int {
    if x > 0 {
        return x
    }
    return -x
}

