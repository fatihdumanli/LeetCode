package main

import "fmt"

type ListNode struct {
    Val int
    Next *ListNode
}

func main() {
    head := &ListNode{Val: 1, Next: &ListNode{Val: 2, Next: &ListNode{Val: 3, Next: &ListNode{Val: 4, Next: &ListNode{Val: 5}}}}}
    r := reverseList(head)

    fmt.Println(r)
}

// https://leetcode.com/problems/reverse-linked-list/
func reverseList(head *ListNode) *ListNode {
    if head.Next == nil {
        return head
    }

    r := reverseList(head.Next)
    head.Next.Next = head
    head.Next = nil

    return r
}
