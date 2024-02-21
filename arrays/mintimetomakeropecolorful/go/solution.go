package main

import "fmt"

func main() {
    colors := "abaac"
    neededTime := []int{1,2,3,4,5}
    r := minCost(colors, neededTime)
    fmt.Println(r)
}

// https://leetcode.com/problems/minimum-time-to-make-rope-colorful
func minCost(colors string, neededTime []int) int {
    if len(colors) == 1 {
        return 0
    }
    var result = 0

    var left = 0
    var right = 1

    for right < len(colors) {

        // Different
        if colors[left] != colors[right] {
            left = right
            right = left + 1
            continue
        }

        // Same
        var leftTime = neededTime[left]
        var rightTime = neededTime[right]

        // Remove left
        if leftTime <= rightTime {
            result += neededTime[left]

            left = right
            right = left + 1
            continue
        }

        // Remove right
        result += neededTime[right]
        right = right + 1
    }


    return result
}

