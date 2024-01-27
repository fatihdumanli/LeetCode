package main

import (
	"fmt"
	"math"
	"sort"
)

func main() {
    candidates := []int{1,1,2,2,3,3}
    candidates = []int{1,4,2,3,8,7,6,3,2,6}
    candidates = []int{1,1}

    r := combinationSum2(candidates, 1)
    fmt.Println(r)
}


// https://leetcode.com/problems/combination-sum-ii
func combinationSum2(candidates []int, target int) [][]int {
    var result = [][]int{}

    sort.Slice(candidates, func(i, j int) bool {
        return candidates[i] < candidates[j]
    })
     
    var processed = make(map[int]bool)

    for i := 0; i < len(candidates); i++ {
        var num = candidates[i]

        if num > target {
            continue
        }

        if _, ok := processed[num]; ok {
            continue
        }

        if num == target {
            result = append(result, []int{num})
        }

        combine(i + 1, candidates, []int{num}, num, target, &result)

        processed[num] = true
    }

    return result
}

func combine(index int, candidates []int, prefix []int, sum int, target int, result *[][]int) {

    var prev = math.MinInt32

    for i := 0; i < len(candidates) - index; i++ {

        var nextIndex = index + i
        var nextNum = candidates[nextIndex]

        if nextNum == prev {
            continue
        }

        prev = nextNum

        sum += nextNum

        if sum > target {
            return
        }

        if sum == target {
            var cpy = make([]int, len(prefix))
            copy(cpy, prefix)
            cpy = append(cpy, nextNum)
            *result = append(*result, cpy)
            return
        }

        var cpy = make([]int, len(prefix))
        copy(cpy, prefix)
        cpy = append(cpy, nextNum)

        combine(nextIndex + 1, candidates, cpy, sum, target, result)
        sum -= nextNum
    }

}

