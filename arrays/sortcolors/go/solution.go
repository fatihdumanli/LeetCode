package main

import "fmt"

func main() {
    nums := []int{2,0,2,1,1,0}

    sortColors(nums);

    fmt.Println("ok")
}

// https://leetcode.com/problems/sort-colors
func sortColors(nums []int) {

    var currentNum = 0;
    var ptr = 0;

    for currentNum <= 2 {
        var foundIdx = -1;

        for k := ptr; k < len(nums); k++ {
            if nums[k] == currentNum {
                foundIdx = k;
                break;
            }
        }
        
        if foundIdx == -1 {
            currentNum++;
            continue;
        }

        var temp = nums[ptr];
        nums[ptr] = currentNum;
        nums[foundIdx] = temp;
        ptr++;
    }
}



