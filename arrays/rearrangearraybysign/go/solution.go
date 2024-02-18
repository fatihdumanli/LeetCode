package main

import "fmt"

type ListNode struct {
    Val int
    Next *ListNode
}

func main() {
    nums := []int{-26, 19, -37, -10, -9, 15, 14, 31}
    r := rearrangeArray(nums)
    fmt.Println(r)
}

func rearrangeArray(nums []int) []int {
    var result []int = make([]int, len(nums))

    var positives *ListNode = &ListNode{}
    var negatives *ListNode = &ListNode{}

    var ptrPositive = positives
    var ptrNegative = negatives

    for i := 0; i < len(nums); i++ {
        var num = nums[i]
        if num < 0 {
            ptrNegative.Next = &ListNode{Val: num}
            ptrNegative = ptrNegative.Next
        } else {
            ptrPositive.Next = &ListNode{Val: num}
            ptrPositive = ptrPositive.Next
        }
    }

    ptrPositive = positives.Next
    ptrNegative = negatives.Next
    var resultPtr = 0

    for ptrPositive != nil || ptrNegative != nil {
        result[resultPtr] = ptrPositive.Val
        resultPtr++
        ptrPositive = ptrPositive.Next
        result[resultPtr] = ptrNegative.Val
        resultPtr++
        ptrNegative = ptrNegative.Next
    }

    return result
}

