package main

import (
	"dsa"
	"fmt"
	"math"
)

type ListNode = dsa.ListNode

func main() {

	midPoint := ListNode{Val: 3, Next: &ListNode{Val: 4}}

	l1 := ListNode{Val: 1, Next: &ListNode{Val: 2, Next: &midPoint}}
	l2 := ListNode{Val: 8, Next: &ListNode{Val: 7, Next: &ListNode{Val: 5, Next: &ListNode{Val: 6, Next: &midPoint}}}}
	res, _ := doTheyIntersect(&l1, &l2)
	fmt.Println(res)
}

func doTheyIntersect(l1, l2 *ListNode) (bool, *ListNode) {
	l1Length := float64(getLength(l1))
	l2Length := float64(getLength(l2))

	diff := int(math.Abs(l1Length - l2Length))

	if l1Length < l2Length {
		l2 = padRight(l2, diff)
	} else if l2Length < l1Length {
		l1 = padRight(l1, diff)
	}

	for l1 != nil && l2 != nil {
		if l1 == l2 {
			return true, l1
		}

		l1 = l1.Next
		l2 = l2.Next
	}

	return false, nil
}

func padRight(longer *ListNode, steps int) *ListNode {
	for i := 0; i < steps; i++ {
		longer = longer.Next
	}
	return longer
}

func getLength(head *ListNode) int {

	ptr := head
	length := 0
	for ptr != nil {
		length++
		ptr = ptr.Next
	}
	return length
}
