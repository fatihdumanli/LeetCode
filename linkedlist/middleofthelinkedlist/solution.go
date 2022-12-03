package main

//https://leetcode.com/problems/middle-of-the-linked-list/
func middleNode(head *ListNode) *ListNode {

	var slow *ListNode = head
	var fast *ListNode = head.Next

	for fast != nil && fast.Next != nil {
		fast = fast.Next.Next
		slow = slow.Next
	}

	if fast == nil {
		return slow
	}

	return slow.Next
}

type ListNode struct {
	Val  int
	Next *ListNode
}
