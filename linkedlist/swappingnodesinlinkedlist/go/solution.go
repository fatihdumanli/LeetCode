package main

import "fmt"

type ListNode struct {
    Val int
    Next *ListNode
}

func main() {
    head := &ListNode{Val: 1, Next: &ListNode{Val: 2, Next: &ListNode{Val: 3, Next: &ListNode{Val: 4}}}}
    r := swapNodes(head, 2)
    fmt.Println(r)
}

// https://leetcode.com/problems/swapping-nodes-in-a-linked-list
// This solution swaps the NODES - not the values (node pointers)
// Which is more complicated than what the question asks for
// Of course it's terrible that I realized that fact after submitting the
// solution :) - I could've just swap the values after finding out relevant
// nodes.
func swapNodes(head *ListNode, k int) *ListNode {

    if head.Next == nil {
        return head
    }

    // 2 nodes
    if head.Next.Next == nil {
        var temp = head
        var temp2 = head.Next

        head.Next = nil
        temp2.Next = temp
        return temp2
    }

    // Get the length of the list
    var length = 0
    var ptr = head
    
    for ptr != nil {
        length++
        ptr = ptr.Next
    }

    // Swap head with tail
    if k == length {
        ptr = head
        for i := 0; i < k - 2; i++ {
            ptr = ptr.Next
        }

        var temp = head
        var tempNext = head.Next

        var newHead = ptr.Next
        ptr.Next = temp
        ptr.Next.Next = nil

        head = newHead
        head.Next = tempNext
        return head
    }


    var leftNodePrefix, leftNode, leftNodeNext *ListNode
    var rightNodePrefix, rightNode, rightNodeNext *ListNode

    ptr = head

    if k == 1 {
        leftNodePrefix = nil
        leftNode = head
    } else {
        for i := 0; i < k - 2; i++ {
            ptr = ptr.Next
        }
        leftNodePrefix = ptr
        leftNode = ptr.Next
    }
    leftNodeNext = leftNode.Next

    ptr = head

    for i := 0; i < length - k - 1; i++ {
        ptr = ptr.Next
    }

    rightNodePrefix = ptr
    rightNode = ptr.Next
    rightNodeNext = rightNode.Next


    // Consecutive leftNode -> rightNode
    if leftNode.Next == rightNode {
        rightNode.Next = nil
        leftNodePrefix.Next = rightNode 
        leftNode.Next = nil
        leftNode.Next = rightNodeNext
        rightNode.Next = leftNode
        return head
    }

    // Consecutive rightNode -> leftNode 
    if rightNode.Next == leftNode {
        leftNode.Next = nil
        rightNodePrefix.Next = leftNode
        rightNode.Next = leftNodeNext
        rightNodePrefix.Next.Next = rightNode
        return head
    }

    // Connect left to the right
    leftNode.Next = nil
    rightNodePrefix.Next = leftNode
    rightNodePrefix.Next.Next = rightNodeNext

    rightNode.Next = nil

    if leftNodePrefix == nil {
        rightNode.Next = leftNodeNext
        head = rightNode
    } else {
        leftNodePrefix.Next = rightNode
        leftNodePrefix.Next.Next = leftNodeNext
    }

    return head
}
