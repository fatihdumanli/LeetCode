package main

import "fmt"

type ListNode struct {
    Val int
    Next *ListNode
}

func main() {
    head := &ListNode{Val: 1, Next: &ListNode{Val: 2, Next: &ListNode{Val: 3, Next: &ListNode{Val: 4, Next: &ListNode{Val: 5}}}}}
     head = &ListNode{Val: 1, Next: &ListNode{Val: 2, Next: &ListNode{Val: 3, Next: &ListNode{Val: 4}}}}
    reorderList(head)
    fmt.Println(head)
}

// https://leetcode.com/problems/reorder-list
func reorderList(head *ListNode) {
    // Step 1: Reverse the other half of the list
    // Step 2: Place two pointers
    // Step 3: Merge two lists

    // 1 -> 2 -> 3 -> 4 -> 5 -> NULL
    // 1 -> 2 -> 3 -> NULL
    // 5 -> 4 -> NULL
    // 
    //
    // 1-> 5 -> 2 -> 4 -> 3 -> NULL

    // Get the length of the list
    var length = 0
    var ptr = head

    // 1-> 2 -> 3 -> null
    for ptr != nil {
        ptr = ptr.Next
        length++
    }
    var half = length / 2
    ptr = head

    // Odd-numbered nodes, the middle node should stay in the first part
    if length % 2 == 1 {
        half += 1
    }

    for i := 0; i < half; i++ {
        var temp = ptr
        ptr = ptr.Next
        if i == half - 1 {
            temp.Next = nil
        }
    }

    reversed := reverse(ptr)

    var headPtr = head
    for reversed != nil {

        var temp = headPtr.Next
        headPtr.Next = &ListNode{Val: reversed.Val}

        reversed = reversed.Next
        headPtr = headPtr.Next
        headPtr.Next = temp
        headPtr = headPtr.Next
    }
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

