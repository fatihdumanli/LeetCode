package main

import "fmt"

type ListNode struct {
    Val int
    Next *ListNode
}

func main() {
    // head := &ListNode{Val: 4, Next: &ListNode{Val: 2, Next: &ListNode{Val: 1, Next: &ListNode{Val: 3}}}}
    head := &ListNode{Val: -1, Next: &ListNode{Val: 5, Next: &ListNode{Val: 3, Next: &ListNode{Val: 4, Next: &ListNode{Val: 0}}}}}

    r := insertionSortList(head)
    fmt.Println(r)
}

// https://leetcode.com/problems/insertion-sort-list
func insertionSortList(head *ListNode) *ListNode {
    if head.Next == nil {
        return head
    }

    // At least 2 nodes
    var sorted *ListNode = &ListNode{Val: head.Val}
    head = head.Next

    for head != nil {
        var node = head
        head = head.Next

        v := insert(sorted, node.Val)

        if v != nil {
            v.Next = sorted
            sorted = v
        }
    }

    return sorted
}

// Returns other than nil if the node needs to be inserted to the head
func insert(sorted *ListNode, val int) *ListNode {
    // At least one node
    var ptr = sorted

    // Insert to head
    if val <= sorted.Val {
        var newSorted = &ListNode{Val: val}
        return newSorted
    }

    for ptr.Next != nil && ptr.Next.Val < val {
        ptr = ptr.Next
    }


    // Insert to tail
    if ptr.Next == nil {
        ptr.Next = &ListNode{Val: val}
        return nil
    }

    var temp = ptr.Next
    ptr.Next = &ListNode{Val: val}
    ptr.Next.Next = temp

    return nil
}
