package main

import (
    "math"
    "fmt"
)

func main() {
    var word = "abcdefghijk"
    r := minimumPushes(word)
    fmt.Println(r)
}

// https://leetcode.com/problems/minimum-number-of-pushes-to-type-word-i/
func minimumPushes(word string) int {
    // abcdefgh ijklmnoprstuv
    var result = 0

    // 2, 3, 4, 5, 6, 7, 8, 9
    for i := 0; i < len(word); i++ {
        var len = i + 1

        var div = float64(len) / float64(8)
        var ceil float64 = math.Ceil(div)

        result = result + int(ceil)
    }
    
    return result
}
