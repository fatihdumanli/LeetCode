package main

import (
	"fmt"
)

//https://leetcode.com/problems/top-k-frequent-elements/
func main() {
	var nums []int = []int{4, 1, -1, 2, -1, 2, 3}
	fmt.Println(topKFrequent(nums, 2))
}

type HeapNode struct {
	Freq int
	Val  int
}

func insert(heap *[]HeapNode, val HeapNode) {
	var idx = len(*heap)
	*heap = append(*heap, val)

	var parentIdx = (idx - 1) / 2
	var parent = (*heap)[parentIdx]

	for idx > 0 && val.Freq > (*heap)[parentIdx].Freq {
		//bubble up the node.
		var temp = parent
		(*heap)[parentIdx] = (*heap)[idx]
		(*heap)[idx] = temp
		idx = parentIdx
		if idx == 0 {
			break
		}
		parentIdx = (idx - 1) / 2
	}

}

func extractMax(h *[]HeapNode) *HeapNode {
	var max = (*h)[0]

	var ha = (*h)[0]
	_ = ha
	swap(&(*h)[0], &(*h)[len(*h)-1])

	//chop off the last element
	*h = (*h)[:len(*h)-1]

	idx := 0

	//Eval the indexes of left and right child
	left := (2 * idx) + 1
	right := (2 * idx) + 2

	//Bubble down the root as long as one of its children is less than it
	var shouldBubbleDown = func() bool {
		boundaries := left < len(*h) && right < len(*h)
		if !boundaries {
			return false
		}
		return boundaries && (*h)[idx].Freq < (*h)[left].Freq || (*h)[idx].Freq < (*h)[right].Freq
	}

	//Bubble down the root as long as one of its children is less than it
	for shouldBubbleDown() {

		//If the left child is less than the root, swap(root, left)
		var oldfreqArr []int
		for _, v := range *h {
			oldfreqArr = append(oldfreqArr, v.Freq)
		}

		if (*h)[left].Freq > (*h)[right].Freq {
			swap(&(*h)[left], &(*h)[idx])
			idx = left
		} else {
			//If the right child is less than the root, swap(root, left)
			swap(&(*h)[right], &(*h)[idx])
			idx = right
		}

		var newfreqArr = []int{}
		for _, v := range *h {
			newfreqArr = append(newfreqArr, v.Freq)
		}
		left = (2 * idx) + 1
		right = (2 * idx) + 2
	}

	return &max
}

func swap(a *HeapNode, b *HeapNode) {
	var temp = *a
	*a = *b
	*b = temp
}

func topKFrequent(nums []int, k int) []int {

	var result []int
	//key: val, val: freq
	var hashmap map[int]int = make(map[int]int, 0)

	for _, n := range nums {
		_, ok := hashmap[n]
		if ok {
			hashmap[n]++
		} else {
			hashmap[n] = 1
		}
	}

	var heap []HeapNode

	for k, v := range hashmap {
		insert(&heap, HeapNode{Val: k, Freq: v})
	}

	for len(result) < k {
		var max = extractMax(&heap)
		result = append(result, max.Val)
	}

	return result
}

//With hashmap
//	//key: val, val: freq
//	var hashmap map[int]int = make(map[int]int, 0)
//	var max = math.MinInt32
//
//	for _, n := range nums {
//		_, ok := hashmap[n]
//		if ok {
//			hashmap[n]++
//			if hashmap[n] > max {
//				max = hashmap[n]
//			}
//		} else {
//			hashmap[n] = 1
//		}
//	}
//
//	if max == math.MinInt32 {
//		max = 1
//	}
//
//	//key: freq, val: val
//	var orderedHashmap map[int][]int = make(map[int][]int, 0)
//	for k, v := range hashmap {
//		var _, ok = orderedHashmap[v]
//		if ok {
//			orderedHashmap[v] = append(orderedHashmap[v], k)
//		} else {
//			orderedHashmap[v] = []int{k}
//		}
//	}
//
//	var result []int
//
//	for len(result) < k {
//		result = append(result, orderedHashmap[max]...)
//		max--
//	}
//
//	return result
