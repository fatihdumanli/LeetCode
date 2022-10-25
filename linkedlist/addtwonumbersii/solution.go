package main

import "fmt"

type ListNode struct {
	Val  int
	Next *ListNode
}

//https://leetcode.com/problems/add-two-numbers-ii/
func main() {
	l1 := &ListNode{Val: 9, Next: &ListNode{Val: 1, Next: &ListNode{Val: 6}}}
	l2 := &ListNode{Val: 0}

	r := addTwoNumbers(l1, l2)
	fmt.Println(r)
}

func addTwoNumbers(l1 *ListNode, l2 *ListNode) *ListNode {

	var l1Length = getLength(l1)
	var l2Length = getLength(l2)

	// find the shorter one, and add additional zero nodes to the head
	if l1Length < l2Length {
		l1 = addNZeroNodesToTheHead(l1, l2Length-l1Length)
	} else {
		l2 = addNZeroNodesToTheHead(l2, l1Length-l2Length)
	}

	var result, carry = helper(l1, l2)
	if carry > 0 {
		var newNode = ListNode{Val: carry, Next: result}
		return &newNode
	}

	return result
}

func helper(l1 *ListNode, l2 *ListNode) (*ListNode, int) {
	if l1 == nil {
		return nil, 0
	}

	var resultNode, carry = helper(l1.Next, l2.Next)

	var sum = l1.Val + l2.Val + carry
	carry = sum / 10
	sum = sum % 10

	var newNode = &ListNode{Val: sum}
	newNode.Next = resultNode

	return newNode, carry
}

func addNZeroNodesToTheHead(head *ListNode, n int) *ListNode {
	if n <= 0 {
		return head
	}
	var newHead = &ListNode{Val: 0}
	var ptr = newHead

	for i := 0; i < n-1; i++ {
		ptr.Next = &ListNode{Val: 0}
		ptr = ptr.Next
	}

	ptr.Next = head
	return newHead
}

func getLength(l *ListNode) int {
	var length = 0

	var ptr = l

	for ptr != nil {
		length++
		ptr = ptr.Next
	}

	return length
}
