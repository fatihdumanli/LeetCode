package main

import "fmt"

func main() {
    var nums = []int{2,7,11,15}
    target := 9

    r := twoSum(nums, target)
    fmt.Println(r)
}

func twoSum(nums []int, target int) []int {
    var hashmap = make(map[int]int)

    for i := 0; i < len(nums); i++ {

        var num = nums[i]
        var search = target - num

        if v, ok := hashmap[search]; ok {
            return []int{v, i}
        }

        hashmap[num] = i
    }

    return []int{}
}
