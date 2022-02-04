package main

import (
	"dsa"
	"fmt"
)

type ListNode = dsa.ListNode

func main() {

	head := ListNode{Val: 4}
	head.Next = &ListNode{Val: 3}
	head.Next.Next = &ListNode{Val: 2}
	head.Next.Next.Next = &ListNode{Val: 3}
	head.Next.Next.Next.Next = &ListNode{Val: 1}
	head.Next.Next.Next.Next.Next = &ListNode{Val: 7}
	head.Next.Next.Next.Next.Next.Next = &ListNode{Val: 2}
	head.Next.Next.Next.Next.Next.Next.Next = &ListNode{Val: 8}
	head.Next.Next.Next.Next.Next.Next.Next.Next = &ListNode{Val: 9}

	dsa.PrintLinkedList(&head)

	removeDuplicates2(&head)
	fmt.Println("\n---------------------------")
	dsa.PrintLinkedList(&head)
}

//O(n^2) time and constant space complexity
func removeDuplicates2(head *ListNode) *ListNode {
	if head == nil {
		return nil
	}

	current := head

	for current != nil {
		runner := current
		for runner != nil && runner.Next != nil {
			if runner.Next.Val == current.Val {
				runner.Next = runner.Next.Next
			}
			runner = runner.Next
		}
		current = current.Next
	}

	return head
}

//O(n) time and O(n) space complexity
func removeDuplicates(head *ListNode) *ListNode {
	if head == nil {
		return nil
	}

	var hashset = make(map[int]bool, 0)
	ptr := head.Next
	prev := head

	for ptr != nil {
		if hashset[ptr.Val] {
			prev.Next = ptr.Next
		}

		hashset[ptr.Val] = true

		prev = ptr
		ptr = ptr.Next
	}
	return head
}
