package main

import "fmt"

type ListNode struct {
    Val int
    Next *ListNode
}

func main() {
    list1 := &ListNode{Val: 1, Next: &ListNode{Val: 2, Next: &ListNode{Val: 4}}}
    list2 := &ListNode{Val: 1, Next: &ListNode{Val: 3, Next: &ListNode{Val: 4}}}

    r := mergeTwoLists(list1, list2)
    fmt.Println(r)
}

// https://leetcode.com/problems/merge-two-sorted-lists/
func mergeTwoLists(list1 *ListNode, list2 *ListNode) *ListNode {
    var newHead *ListNode = &ListNode{}
    var ptr = newHead

    for list1 != nil || list2 != nil {
        if list1 == nil {
            ptr.Next = &ListNode{Val: list2.Val}
            ptr = ptr.Next
            list2 = list2.Next
            continue
        }
        if list2 == nil {
            ptr.Next = &ListNode{Val: list1.Val}
            ptr = ptr.Next
            list1 = list1.Next
            continue
        }

        // Both of them is non-nil
        if list1.Val <= list2.Val {
            ptr.Next = &ListNode{Val: list1.Val}
            ptr = ptr.Next
            list1 = list1.Next
        } else {
            ptr.Next = &ListNode{Val: list2.Val}
            ptr = ptr.Next
            list2 = list2.Next
        }
    }

    return newHead.Next
}

