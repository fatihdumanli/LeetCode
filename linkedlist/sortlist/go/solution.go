package main

import "fmt"

type ListNode struct {
    Val int
    Next *ListNode
}

func main() {
    head := &ListNode{Val: 4, Next: &ListNode{Val: 2, Next: &ListNode{Val: 1, Next: &ListNode{Val: 3}}}}

    r := sortList(head)
    fmt.Println(r)
}

// https://leetcode.com/problems/sort-list/
// Idea here is to apply merge sort
// Find first and second half - using slow and fast ptr
func sortList(head *ListNode) *ListNode {
    if head == nil {
        return nil
    }

    var ptr = head

    if head.Next == nil {
        return head
    }

    if head.Next.Next == nil {
        if head.Val <= head.Next.Val {
            return &ListNode{Val: head.Val, Next: &ListNode{Val: head.Next.Val}}
        } else {
            return &ListNode{Val: head.Next.Val, Next: &ListNode{Val: head.Val}}
        }
    }

    // Here it's guaranteed to have at least 3 nodes
    var slow = head
    var fast = head.Next

    for fast != nil && fast.Next != nil {
        slow = slow.Next
        fast = fast.Next
        fast = fast.Next
    }

    var right = slow.Next
    slow.Next = nil

    l := sortList(head)
    r := sortList(right)

    var newHead *ListNode = &ListNode{}
    ptr = newHead

    for l != nil || r != nil {
        if l == nil {
            ptr.Next = &ListNode{Val: r.Val}
            r = r.Next
            ptr = ptr.Next
            continue
        }

        if r == nil {
            ptr.Next = &ListNode{Val: l.Val}
            l = l.Next
            ptr = ptr.Next
            continue
        }

        // Both of them are non-nil
        if l.Val <= r.Val {
            ptr.Next = &ListNode{Val: l.Val}
            l = l.Next
        } else {
            ptr.Next = &ListNode{Val: r.Val}
            r = r.Next
        }
        ptr = ptr.Next
    }

    return newHead.Next
}

