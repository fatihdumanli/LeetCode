package main

import "fmt"

func main() {
    nums1 := []int{1,2,3}
    nums2 := []int{2,4}

    r := getCommon(nums1, nums2)
    fmt.Println(r)
}

// https://leetcode.com/problems/minimum-common-value
func getCommon(nums1 []int, nums2 []int) int {

    var arr2hashset = make(map[int]bool)

    for i := 0; i < len(nums2); i++ {
        var num = nums2[i]
        arr2hashset[num] = true
    }

    for i := 0; i < len(nums1); i++ {
        var num = nums1[i]
        if _, ok := arr2hashset[num]; ok {
            return num
        }
    }

    return -1
}
