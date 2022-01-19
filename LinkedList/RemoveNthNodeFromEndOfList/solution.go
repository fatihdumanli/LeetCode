package main

type ListNode struct {
	Val  int
	Next *ListNode
}

func main() {
	/*
		head := ListNode{Val: 1}
		head.Next = &ListNode{Val: 2}
		head.Next.Next = &ListNode{Val: 3}
		head.Next.Next.Next = &ListNode{Val: 4}
		head.Next.Next.Next.Next = &ListNode{Val: 5}
	*/

	head := ListNode{Val: 1}
	removeNthFromEnd(&head, 1)

}

func removeNthFromEnd(head *ListNode, n int) *ListNode {
	ptr := head
	helper(ptr, n)
	return head
}

func helper(head *ListNode, n int) int {
	if head == nil {
		return 0
	}
	res := helper(head.Next, n)

	if res == n {
		head.Next = head.Next.Next
	}

	return res + 1
}
