package main

import (
	"dsa"
	"fmt"
	"os"
)

type ListNode = dsa.ListNode

func main() {
	listNode := ListNode{Val: 1}
	listNode.Next = &ListNode{Val: 2}
	listNode.Next.Next = &ListNode{Val: 3}
	listNode.Next.Next.Next = &ListNode{Val: 4}

	result := kThElementToTheLast(&listNode, 4)
	_ = result

	if result == nil {
		fmt.Println("the list shorter than k!")
		os.Exit(1)
	}

	fmt.Println(result.Val)
}

func kThElementToTheLast(head *ListNode, k int) *ListNode {
	_, result := helper(head, k)
	return result
}

func helper(head *ListNode, k int) (int, *ListNode) {
	if head == nil {
		return 1, nil
	}

	n, node := helper(head.Next, k)
	if n == k {
		return n + 1, head
	}
	return n + 1, node
}

/*
func kThElementToTheLast(head *ListNode, k int) *ListNode {
	ptr := head
	size := 0

	for ptr != nil {
		size++
		ptr = ptr.Next
	}

	stepsToTake := size - k

	ptr = head

	for i := 0; i < stepsToTake; i++ {
		ptr = ptr.Next
	}

	return ptr
}
*/
