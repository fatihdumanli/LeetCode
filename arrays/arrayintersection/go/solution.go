package main

import "fmt"

func main() {
    nums1 := []int{1,2,3,4,5,6}
    nums2 := []int{9,10,11,4,1,7,3}

    r := intersection(nums1, nums2)
    fmt.Println(r)
}

// https://leetcode.com/problems/intersection-of-two-arrays
func intersection(nums1 []int, nums2 []int) []int {

    var hashset1 = make(map[int]bool)

    for i := 0; i < len(nums1); i++ {
        var num = nums1[i]
        hashset1[num] = true
    }


    var hashset2 = make(map[int]bool)
    var result = []int{}

    for i := 0; i < len(nums2); i++ {
        var num = nums2[i]

        if _, ok := hashset2[num]; ok {
            continue
        }

        if _, ok := hashset1[num]; ok {
            result = append(result, num)
            hashset2[num] = true
        }

    }

    return result
}
