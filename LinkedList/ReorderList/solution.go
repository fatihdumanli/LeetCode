package main

import "fmt"

type Queue struct {
}
type ListNode struct {
	Val  int
	Next *ListNode
}

func main() {
	head := ListNode{Val: 1}
	head.Next = &ListNode{Val: 2}
	head.Next.Next = &ListNode{Val: 3}
	head.Next.Next.Next = &ListNode{Val: 4}
	reorderList(&head)
}

func reorderList(head *ListNode) {

	if head.Next == nil {
		return
	}
	var queue []int
	var stack []int

	slow := head
	fast := head

	for fast != nil && fast.Next != nil {
		slow = slow.Next
		enqueue(&queue, slow.Val)
		fast = fast.Next.Next
	}

	for slow != nil {
		slow = slow.Next
		if slow != nil {
			push(&stack, slow.Val)
		}
	}

	fmt.Println(head.Val)
	for len(queue) > 0 && len(stack) > 0 {
		head.Next = &ListNode{
			Val: pop(&stack),
		}
		head = head.Next
		fmt.Println(head.Val)

		head.Next = &ListNode{
			Val: dequeue(&queue),
		}
		head = head.Next
		fmt.Println(head.Val)

	}

	if len(stack) > 0 {
		head.Next = &ListNode{
			Val: pop(&stack),
		}
		head = head.Next
		fmt.Println(head.Val)
	}

	if len(queue) > 0 {
		head.Next = &ListNode{
			Val: dequeue(&queue),
		}
		head = head.Next
		fmt.Println(head.Val)
	}

}

func dequeue(q *[]int) int {
	top := (*q)[0]
	*q = (*q)[1:]
	return top
}

func pop(s *[]int) int {
	top := (*s)[len(*s)-1]
	*s = (*s)[:len(*s)-1]
	return top
}
func enqueue(q *[]int, val int) {
	*q = append(*q, val)
}

func push(s *[]int, val int) {
	*s = append(*s, val)
}
