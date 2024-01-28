package main

type ListNode struct {
	Val  int
	Next *ListNode
}

func main() {

	headA := ListNode{Val: 1}
	headA.Next = &ListNode{Val: 4}
	headA.Next.Next = &ListNode{Val: 5}
	headA.Next.Next.Next = &ListNode{Val: 6}

	headB := ListNode{Val: 7}
	headB.Next = &ListNode{Val: 10}
	headB.Next.Next = &ListNode{Val: 15}
	headB.Next.Next.Next = &ListNode{Val: 20}

	mergeTwoLists(&headA, &headB)
}

func mergeTwoLists(list1 *ListNode, list2 *ListNode) *ListNode {

	var sortedHead = &ListNode{
		Val: 0,
	}

	var ptr = sortedHead

	for list1 != nil && list2 != nil {
		if list2.Val < list1.Val {
			ptr.Next = &ListNode{Val: list2.Val}
			list2 = list2.Next
		} else {
			ptr.Next = &ListNode{Val: list1.Val}
			list1 = list1.Next
		}
		ptr = ptr.Next
	}

	for list1 != nil {
		ptr.Next = &ListNode{Val: list1.Val}
		list1 = list1.Next
		ptr = ptr.Next
	}

	for list2 != nil {
		ptr.Next = &ListNode{Val: list2.Val}
		list2 = list2.Next
		ptr = ptr.Next
	}

	return sortedHead.Next
}
