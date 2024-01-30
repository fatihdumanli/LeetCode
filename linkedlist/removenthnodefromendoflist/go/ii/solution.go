package main

import "fmt"

type ListNode struct {
    Val int
    Next *ListNode
}

// https://leetcode.com/problems/remove-nth-node-from-end-of-list/
func main() {
    head := &ListNode{Val: 1, Next: &ListNode{Val: 2, Next: &ListNode{Val: 3, Next: &ListNode{Val: 4, Next: &ListNode{Val: 5}}}}}
    n := 2
    r := removeNthFromEnd(head, n)
    fmt.Println(r)
}

func removeNthFromEnd(head *ListNode, n int) *ListNode {
    r := helper(head, n)

    if n == r {
        return head.Next
    }

    return head
}

func helper(head *ListNode, n int) int {
    if head.Next == nil {
        return 1
    }

    var r = helper(head.Next, n)
    if r == n {
        head.Next = head.Next.Next
    }
    return r + 1
}

