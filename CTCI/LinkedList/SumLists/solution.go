package main

import "dsa"

type ListNode = dsa.ListNode

func main() {
	l1 := ListNode{Val: 9}
	l2 := ListNode{Val: 9}

	result := sumOfLists(&l1, &l2)
	dsa.PrintLinkedList(result)
}

func sumOfLists(l1, l2 *ListNode) *ListNode {
	result := ListNode{}
	ptr := &result
	carry := 0

	for l1 != nil || l2 != nil {

		firstValue := 0
		secondValue := 0

		if l1 != nil {
			firstValue = l1.Val
		}

		if l2 != nil {
			secondValue = l2.Val
		}
		sum := (firstValue + secondValue + carry) % 10
		carry = (firstValue + secondValue + carry) / 10
		ptr.Next = &ListNode{Val: sum}
		ptr = ptr.Next

		if l1 != nil {
			l1 = l1.Next
		}
		if l2 != nil {
			l2 = l2.Next
		}
	}

	if carry != 0 {
		ptr.Next = &ListNode{Val: carry}
	}

	return result.Next
}
