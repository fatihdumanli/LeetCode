package main

import "fmt"

//https://leetcode.com/problems/odd-even-linked-list/
func main() {
	//head := &ListNode{Val: 1, Next: &ListNode{Val: 2, Next: &ListNode{Val: 3, Next: &ListNode{Val: 4, Next: &ListNode{Val: 5}}}}}
	head := &ListNode{Val: 1, Next: &ListNode{Val: 2}}
	r := oddEvenList(head)
	fmt.Println(r)
}

func oddEvenList(head *ListNode) *ListNode {
	if head == nil {
		return nil
	}

	var odd = head
	var even = head.Next
	var evenPtr = even

	for odd.Next != nil && evenPtr.Next != nil {
		odd.Next = odd.Next.Next
		evenPtr.Next = evenPtr.Next.Next

		odd = odd.Next
		evenPtr = evenPtr.Next
	}

	odd.Next = even

	return head
}

type ListNode struct {
	Val  int
	Next *ListNode
}
