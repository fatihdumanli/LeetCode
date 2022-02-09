package main

import (
	"dsa"
	"fmt"
)

type ListNode = dsa.ListNode

func main() {
	head := ListNode{Val: 1}
	head.Next = &ListNode{Val: 2}
	head.Next.Next = &ListNode{Val: 3}
	head.Next.Next.Next = &ListNode{Val: 2}
	head.Next.Next.Next.Next = &ListNode{Val: 1}

	res := isPalindrome(&head)
	fmt.Println(res)
}

func isPalindrome(head *ListNode) bool {
	sz := getSize(head)

	//iterativeResult := iterative(head, sz)
	ok, _ := recursive(head, sz)
	//_ = iterativeResult

	return ok
}

func recursive(head *ListNode, length int) (bool, *ListNode) {

	if length == 0 {
		return true, head
	}

	if length == 1 {
		return true, head.Next
	}

	ok, node := recursive(head.Next, length-2)

	if !ok {
		return false, nil
	}

	if node.Val != head.Val {
		return false, nil
	}

	node = node.Next

	return true, node
}

func iterative(head *ListNode, length int) bool {
	var s = make([]int, 0)

	ptr := head
	i := 0
	for ; i < length/2; i++ {
		s = append(s, ptr.Val)
		ptr = ptr.Next
	}

	if length%2 == 1 {
		ptr = ptr.Next
	}

	for ptr != nil {
		popped := pop(&s)
		if popped != ptr.Val {
			return false
		}
		ptr = ptr.Next
	}

	return true
}

func pop(s *[]int) int {
	var top = (*s)[len(*s)-1]
	*s = (*s)[:len(*s)-1]
	return top
}

func getSize(head *ListNode) int {
	ptr := head
	cnt := 0

	for ptr != nil {
		cnt++
		ptr = ptr.Next
	}
	return cnt
}
