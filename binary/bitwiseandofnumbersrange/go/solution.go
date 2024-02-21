package main

import "fmt"

func main() {
    r := rangeBitwiseAnd(2, 4)
    fmt.Println(r)
}

func raneBitwiseAnd(left int, right int) int {
    func rangeBitwiseAnd(left int, right int) int {

    var result = left

    for i := left + 1; i <= right; i++ {
        result &= i
        if result == 0 {
            return result
        }
    }
    return result
}
}

