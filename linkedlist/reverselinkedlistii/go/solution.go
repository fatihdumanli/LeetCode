package main

import "fmt"

type ListNode struct {
    Val int
    Next *ListNode
}

func main() {
    // head := &ListNode{Val: 1, Next: &ListNode{Val: 2, Next: &ListNode{Val: 3, Next: &ListNode{Val: 4, Next: &ListNode{Val: 5}}}}}
    head := &ListNode{Val: 1, Next: &ListNode{Val: 2}}
    r := reverseBetween(head, 1, 2)
    fmt.Println(r)
}

// https://leetcode.com/problems/reverse-linked-list-ii
func reverseBetween(head *ListNode, left int, right int) *ListNode {

    // We need to establish 3 pointers.
    // 1: The one that right before the part which is going to be reversed
    // 2: The one that's pointing to the start of the part that's going to be
    // reversed
    // 3: The one that that's pointing to the one that's going to be the first
    // node right after the part that's supposed to be replaced
    // 1-> 2 -> 3 -> 4 -> 5 -> NULL
    // Imagine left = 2 and right = 4
    // 
    // Pointers needed are
    // 1-> NULL
    // 2 -> 3 -> 4 -> NULL
    // 5 -> NULL

    // After reversing 2 -> 3 -> 4 -> NULL
    // Now we attach the pointers
    // 1 -> 4 -> 3 -> 2 -> 5 -> NULL
    // Done.

    var one *ListNode
    var two *ListNode
    var three *ListNode

    var ptr = head

    if left == 1 {
        one = nil
        two = head
    } else {
        for i := 0; i < left - 2; i++ {
            ptr = ptr.Next
        }


        two = ptr.Next
        ptr.Next = nil
        one = head
    }

    ptr = two
    var diff = right - left
    for i := 0; i < diff; i++ {
        ptr = ptr.Next
    }

    three = ptr.Next
    ptr.Next = nil

    two = reverse(two)

    return merge(one, two, three)
}

func reverse(head *ListNode) *ListNode {
    if head.Next == nil {
        return head
    }

     r := reverse(head.Next)
     head.Next.Next = head
     head.Next = nil

     return r
}

// either One or three CAN be nil
func merge(one *ListNode, two *ListNode, three *ListNode) *ListNode {
    if one == nil {
        return mergeTwo(two, three)
    } else if (three == nil) {
        return mergeTwo(one, two)
    }

    return mergeTwo(mergeTwo(one, two), three)
}

func mergeTwo(one *ListNode, two *ListNode) *ListNode {
    var head = one
    var ptr = one

    for ptr.Next != nil {
        ptr = ptr.Next
    }

    ptr.Next = two
    return head
}
