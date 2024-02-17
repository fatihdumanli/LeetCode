package main

import (
	"fmt"
        "sort"
	"math"
)

func main() {
    arr := []int{24,157,22,168,374,373,323,328,24,164,104,331,114,152,82,456,343,157,245,443,368,229,49,82,16,373,142}
    k := 23
    r := findLeastNumOfUniqueInts(arr, k)
    fmt.Println(r)
}

// https://leetcode.com/problems/least-number-of-unique-integers-after-k-removals
func findLeastNumOfUniqueInts(arr []int, k int) int {
    var freq map[int]int = make(map[int]int)

    for i := 0; i < len(arr); i++ {
        var num = arr[i]

        if _, ok := freq[num]; ok {
            freq[num]++
        } else {
            freq[num] = 1
        }
    }

    sort.Slice(arr, func(i, j int) bool {
        var num1 = arr[i]
        var num2 = arr[j]

        var freq1 = freq[num1]
        var freq2 = freq[num2]

        if freq1 == freq2 {
            return num1 <= num2
        }

        return freq[num1] < freq[num2]
    })

    var result = 0

    for i := 0; i < k; i++ {
        var nextNumToRemove = arr[i]
        freq[nextNumToRemove] = freq[nextNumToRemove] - 1
    }

    for _, v := range freq {
        if v > 0 {
            result++
        }
    }

    return result
}
