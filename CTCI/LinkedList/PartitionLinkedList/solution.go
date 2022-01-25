package main

import "dsa"

type ListNode = dsa.ListNode

func main() {

	head := ListNode{Val: 7}
	head.Next = &ListNode{Val: 8}
	head.Next.Next = &ListNode{Val: 5}
	head.Next.Next.Next = &ListNode{Val: 1}
	head.Next.Next.Next.Next = &ListNode{Val: 2}

	res := partition(&head, 5)
	dsa.PrintLinkedList(res)

}

func partition(head *ListNode, x int) *ListNode {

	if head == nil {
		return nil
	}

	left := head
	cur := head

	for cur != nil && cur.Next != nil {
		if cur.Next.Val < x {
			tempVal := cur.Next.Val
			cur.Next = cur.Next.Next
			temp := left
			left = &ListNode{Val: tempVal}
			left.Next = temp
			continue
		}
		cur = cur.Next
	}

	return left
}
