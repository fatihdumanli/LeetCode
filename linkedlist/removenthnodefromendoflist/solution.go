package main

import "fmt"

type ListNode struct {
	Val  int
	Next *ListNode
}

func main() {
	head := ListNode{Val: 1}
	head.Next = &ListNode{Val: 2}
	removeNthFromEnd(&head, 2)
	fmt.Println("done")
}

func removeNthFromEnd(head *ListNode, n int) *ListNode {
	var ptr = head
	sz := 0

	for ptr != nil {
		ptr = ptr.Next
		sz++
	}

	if n == sz {
		head = head.Next
	}

	return nil
}
