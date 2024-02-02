package main

import "fmt"

type ListNode struct {
    Val int
    Next *ListNode
}

func main() {
    //( head := &ListNode{Val: 3, Next: &ListNode{Val: 2, Next: &ListNode{Val: 0, Next: &ListNode{Val: -4}}}}
    // head.Next.Next.Next.Next = head.Next
    head := &ListNode{Val: 1, Next: &ListNode{Val: 2, Next: &ListNode{Val: 3, Next: &ListNode{Val: 4}}}}
    head.Next.Next.Next.Next = head.Next

    r := detectCycle(head)
    fmt.Println(r)
}

// https://leetcode.com/problems/linked-list-cycle-ii
func detectCycle(head *ListNode) *ListNode {

    var length = 1
    var slow *ListNode
    var fast *ListNode

    slow = head
    fast = head.Next

    for fast != nil && fast.Next != nil {
        slow = slow.Next
        fast = fast.Next.Next
        length += 2

        if slow == fast {
            break
        }
    }

    // No cycle
    if fast == nil || fast.Next == nil {
        return nil
    }

    // Now we try one by one every node
    // If the fast pointer equals to the fixed one, 
    // That's where the cycle starts

    slow = head
    fast = head.Next

    for slow != nil {
        for i := 0; i < length; i++ {
            if slow == fast {
                return slow
            }
            fast = fast.Next
        }
        slow = slow.Next
    }

    return nil
}

