package main

import "fmt"

type ListNode struct {
    Val int
    Next *ListNode
}

func main() {
    head := &ListNode{Val: 3, Next: &ListNode{Val: 2, Next: &ListNode{Val: 0, Next: &ListNode{Val: -4}}}}
    head.Next.Next.Next.Next = head.Next
    r := detectCycle(head)
    fmt.Println(r)
}

// https://leetcode.com/problems/linked-list-cycle-ii
func detectCycle(head *ListNode) *ListNode {

    var hashset map[*ListNode]bool = make(map[*ListNode]bool)
    var ptr = head

    for ptr != nil {
        if _, ok := hashset[ptr]; ok {
            return ptr
        }

        hashset[ptr] = true
        ptr = ptr.Next
    }

    return nil
}

