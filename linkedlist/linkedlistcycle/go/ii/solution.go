package main

import "fmt"

type ListNode struct {
    Val int
    Next *ListNode
}

func main() {
    head := &ListNode{Val: 3, Next: &ListNode{Val: 2, Next: &ListNode{Val: 0, Next: &ListNode{Val: 4}}}}
    head.Next.Next.Next.Next = head.Next

    r := hasCycle(head)
    fmt.Println(r)
}

func hasCycle(head *ListNode) bool {

    if head == nil {
        return false
    }
    var slow = head
    var fast = head.Next

    for fast != nil && fast.Next != nil {

        if slow == fast {
            return true
        }

        slow = slow.Next
        fast = fast.Next.Next
    }

    return false
}

