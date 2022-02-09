package main

import (
	"dsa"
	"math"
)

type ListNode = dsa.ListNode

func main() {
	l1 := ListNode{Val: 1, Next: &ListNode{Val: 2, Next: &ListNode{Val: 3}}}
	l2 := ListNode{Val: 6, Next: &ListNode{Val: 7}}

	result := sumListsForward(&l1, &l2)
	dsa.PrintLinkedList(result)
}

func sumListsForward(l1, l2 *ListNode) *ListNode {
	s1 := sizeof(l1)
	s2 := sizeof(l2)

	var shorter *ListNode

	if s1 < s2 {
		shorter = l1
	} else {
		shorter = l2
	}

	diff := int(math.Abs(float64(s1) - float64(s2)))
	for i := 0; i < diff; i++ {
		temp := ListNode{}
		temp.Next = shorter

		if shorter == l1 {
			l1 = &temp
		} else {
			l2 = &temp
		}
	}

	_, res := helper(l1, l2)

	return res
}

//  1 -> 2 -> 3 -> nil
//  0 -> 6 -> 7 -> nil
//
func helper(l1, l2 *ListNode) (int, *ListNode) {

	if l1 == nil || l2 == nil {
		return 0, nil
	}

	carry, res := helper(l1.Next, l2.Next)
	sum := carry + l1.Val + l2.Val
	carry = sum / 10
	node := ListNode{Val: sum % 10}
	node.Next = res

	return carry, &node
}

func sizeof(list *ListNode) int {
	ptr := list
	cnt := 0
	for ptr != nil {
		ptr = ptr.Next
		cnt++
	}
	return cnt
}
