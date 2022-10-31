package main

import "fmt"

type ListNode struct {
	Val  int
	Next *ListNode
}

func main() {
	head := &ListNode{Val: 1, Next: &ListNode{Val: 1, Next: &ListNode{Val: 1, Next: &ListNode{Val: 1, Next: &ListNode{Val: 1, Next: &ListNode{Val: 1}}}}}}
	r := deleteDuplicates(head)
	fmt.Println(r)
}

func deleteDuplicates(head *ListNode) *ListNode {
	if head == nil {
		return nil
	}

	ptr := head

	for ptr != nil {

		if ptr.Next == nil {
			return head
		}
		if ptr.Next.Val == ptr.Val {
			ptr.Next = ptr.Next.Next
			continue
		}

		ptr = ptr.Next
	}

	return head
}
