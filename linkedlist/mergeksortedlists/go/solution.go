package main

import (
	"dsa"
	"math"
)

type ListNode = dsa.ListNode

func main() {

	one := &ListNode{Val: 1}
	one.AddNext(4)
	one.AddNext(5)

	two := &ListNode{Val: 1}
	two.AddNext(3)
	two.AddNext(4)

	three := &ListNode{Val: 2}
	three.AddNext(6)

	mergeKLists([]*ListNode{one, two, three})

}

func mergeKLists(lists []*ListNode) *ListNode {
	var bheap []int
	for _, l := range lists {

		var ptr = l
		for ptr != nil {
			bheap = insert(bheap, ptr.Val)
			ptr = ptr.Next
		}
	}

	var newHead = &ListNode{Val: 0}
	var ptr = newHead

	for len(bheap) > 0 {
		ptr.Next = &ListNode{Val: extractMin(&bheap)}
		ptr = ptr.Next
	}

	return newHead.Next
}

func insert(bheap []int, val int) []int {
	if bheap == nil {
		return []int{val}
	}

	i := len(bheap)
	//Add the element to the end of the heap
	bheap = append(bheap, val)

	var parent = bheap[(i-1)/2]

	for val < parent {
		var temp = parent
		bheap[(i-1)/2] = val
		bheap[i] = temp
		i = (i - 1) / 2
		parent = bheap[(i-1)/2]
	}

	return bheap
}

func extractMin(bheap *[]int) int {

	if len(*bheap) == 0 {
		return math.MinInt32
	}

	if len(*bheap) == 1 {
		var min = (*bheap)[0]
		*bheap = (*bheap)[1:]
		return min
	}

	var top = (*bheap)[0]
	var last = (*bheap)[len(*bheap)-1]
	(*bheap)[0] = last

	var idx = 0
	var left = (2 * idx) + 1
	var right = (2 * idx) + 2

	for left < len(*bheap) && right < len(*bheap) && ((*bheap)[left] < (*bheap)[idx] || (*bheap)[right] < (*bheap)[idx]) {

		if (*bheap)[left] < (*bheap)[right] {
			var temp = (*bheap)[left]
			(*bheap)[left] = (*bheap)[idx]
			(*bheap)[idx] = temp
			idx = left
		} else {
			var temp = (*bheap)[right]
			(*bheap)[right] = (*bheap)[idx]
			(*bheap)[idx] = temp
			idx = right
		}
		left = (2 * idx) + 1
		right = (2 * idx) + 2
	}

	*bheap = (*bheap)[:len(*bheap)-1]
	return top
}
