package main

import "fmt"

func main() {
    nums := []int{1,1,2}
    r := permuteUnique(nums)
    fmt.Println(r)
}

// https://leetcode.com/problems/permutations-ii
func permuteUnique(nums []int) [][]int {
    result := [][]int{}

    var hashset = make(map[int]bool)

    for i := 0; i < len(nums); i++ {

        var num = nums[i]

        if _, ok := hashset[num]; ok {
            continue
        }

        nums[i] = 99
        permute([]int{num}, nums, len(nums), &result)
        nums[i] = num

        hashset[num] = true
    }

    return result
}

func permute(prefix []int, rest []int, length int, result *[][]int) {
    if len(prefix) == length {
        var cpy = make([]int, len(prefix))
        copy(cpy, prefix)
        *result = append(*result, cpy)
        return
    }

    var hashset = make(map[int]bool)

    for i := 0; i < len(rest); i++ {
        var num = rest[i]

        if num == 99 {
            continue
        }

        if _, ok := hashset[num]; ok {
            continue
        }

        var cpy = make([]int, len(prefix))
        copy(cpy, prefix)
        cpy = append(cpy, rest[i])
        hashset[num] = true

        var restcpy = make([]int, len(rest))
        copy(restcpy, rest)
        restcpy[i] = 99

        permute(cpy, restcpy, length, result)
    }
}





