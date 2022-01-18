package main

import "fmt"

type ListNode struct {
	Val  int
	Next *ListNode
}

func main() {
	head := &ListNode{
		Val: 1,
		Next: &ListNode{
			Val: 2,
			Next: &ListNode{
				Val: 3,
			},
		},
	}
	head.Next.Next.Next = head
	fmt.Println(hasCycle(head))

}
func hasCycleRunner(head *ListNode) bool {
	if head == nil {
		return false
	}
	var slow *ListNode
	var fast *ListNode

	fast = head.Next
	slow = head

	for fast != nil && fast.Next != nil {
		slow = slow.Next
		fast = fast.Next.Next

		if slow == fast {
			return true
		}
	}
	return false
}

func hasCycle(head *ListNode) bool {
	if head == nil {
		return false
	}

	visited := make(map[*ListNode]bool, 0)
	for head.Next != nil {
		if visited[head] {
			return true
		} else {
			visited[head] = true
		}
		head = head.Next
	}

	return false
}
