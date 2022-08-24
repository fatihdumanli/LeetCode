package main

type ListNode struct {
	Val  int
	Next *ListNode
}

func main() {
	var l1 = &ListNode{Val: 9, Next: &ListNode{Val: 9, Next: &ListNode{Val: 9, Next: &ListNode{Val: 9, Next: &ListNode{Val: 9, Next: &ListNode{Val: 9, Next: &ListNode{Val: 9}}}}}}}
	var l2 = &ListNode{Val: 9, Next: &ListNode{Val: 9, Next: &ListNode{Val: 9, Next: &ListNode{Val: 9}}}}

	addTwoNumbers(l1, l2)

}

func addTwoNumbersRecursive(l1 *ListNode, l2 *ListNode) *ListNode {
	return recursion(l1, l2, 0)
}

func recursion(l1 *ListNode, l2 *ListNode, carry int) *ListNode {

	if l1 == nil && l2 == nil {
		return nil
	}

	var l1Val int
	var l2Val int

	if l1 == nil {
		l1Val = 0
	} else {
		l1Val = l1.Val
	}

	if l2 == nil {
		l2Val = 0
	} else {
		l2Val = l2.Val
	}

	var sum = l1Val + l2Val + carry

	var l1Arg *ListNode = l1
	var l2Arg *ListNode = l2
	
	if l1 == nil {
		l1Arg = nil
	} else {
		l1Arg = l1.Next
	}

	if l2 == nil {
		l2Arg = nil
	} else {
		l2Arg = l2.Next
	}

	return &ListNode{Val: sum % 10, Next: recursion(l1Arg, l2Arg, sum / 10)}
}

func addTwoNumbers(l1 *ListNode, l2 *ListNode) *ListNode {
	var l1Length = getLength(l1)
	var l2Length = getLength(l2)

	if l1Length < l2Length {
		var diff = l2Length - l1Length

		var ptr = l1

		for ptr.Next != nil {
			ptr = ptr.Next
		}

		for i := 0; i < diff; i++ {
			ptr.Next = &ListNode{Val: 0}
			ptr = ptr.Next
		}


	} else if l2Length < l1Length {
		var diff = l1Length - l2Length

		var ptr = l2

		for ptr.Next != nil {
			ptr = ptr.Next
		}

		for i := 0; i < diff; i++ {
			ptr.Next = &ListNode{Val: 0}
			ptr = ptr.Next
		}
	}

	var newHead *ListNode = &ListNode{}
	var newPtr = newHead

	var carry = 0

	for l2 != nil {
		var sum = l1.Val + l2.Val + carry

		carry = sum / 10

		newPtr.Next = &ListNode{Val: sum % 10}
		newPtr = newPtr.Next

		l1 = l1.Next
		l2 = l2.Next
	}

	if carry > 0 {
		newPtr.Next = &ListNode{Val: carry}
	}

	return newHead.Next
}

func getLength(l *ListNode) int {
	var i int = 0

	var head = l

	for head != nil {
		i++
		head = head.Next
	}

	return i
}
