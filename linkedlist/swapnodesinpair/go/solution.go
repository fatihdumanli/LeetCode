package main

import "fmt"

type ListNode struct {
    Val int
    Next *ListNode
}
func main() {
    head := &ListNode{Val: 1, Next: &ListNode{Val: 2, Next: &ListNode{Val: 3, Next: &ListNode{Val: 4, Next: &ListNode{Val: 5, Next: &ListNode{Val: 6}}}}}}
    r := swapPairs(head)
    fmt.Println(r)
}

// https://leetcode.com/problems/swap-nodes-in-pairs
func swapPairs(head *ListNode) *ListNode {

    if head == nil {
        return nil
    }

    if head.Next == nil {
        return head
    }

    var fakeHead = &ListNode{}

    var aPre = fakeHead
    var a = head
    var b = head.Next
    var bNext = b.Next

    for b != nil {
        bNext = b.Next
        aPre.Next = b
        b.Next = a
        a.Next = bNext

        aPre = a
        a = a.Next
        
        if a == nil {
            return fakeHead.Next
        }

        b = a.Next
    }

    return nil
}
