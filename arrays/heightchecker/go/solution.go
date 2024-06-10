package main

import "sort"
import "fmt"

func main() {
    heights := []int{1,1,4,2,1,3}
    r := heightChecker(heights);

    fmt.Println(r);
}

// https://leetcode.com/problems/height-checker
func heightChecker(heights []int) int {

    var original = make([]int, len(heights))

    for i := 0; i < len(heights); i++ {
        original[i] = heights[i];
    }

    sort.Slice(heights, func(i, j int) bool {
        return heights[i] <= heights[j];
    });


    var result = 0;

    for i := 0; i < len(original); i++ {
        if original[i] != heights[i] {
            result++;
        }
    }

    return result;
}

