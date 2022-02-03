package main

import (
	"errors"
	"fmt"
	"log"
)

type MinHeap []int

func main() {

	var heap MinHeap
	var nums = []int{4, 7, 3, 11, 8, 14, 2, 9, 12, 1}

	for _, n := range nums {
		heap.Insert(n)
	}

	for i := 0; i < len(nums); i++ {
		min, err := heap.ExtractMin()
		if err != nil {
			log.Fatal(err)
		}

		fmt.Println(min)
	}
}

func (h *MinHeap) Insert(val int) {

	//Append the element at the end of the heap
	*h = append(*h, val)
	idx := len(*h) - 1

	//Find out the index of its parent
	parentIdx := (idx - 1) / 2

	//Bubble up the element as long as it's parent is greater
	var shouldBubbleUp = func() bool {
		return idx != 0 && val <= (*h)[parentIdx]
	}

	//Bubble up the element as long as it's parent is greater
	for shouldBubbleUp() {
		swap(&(*h)[parentIdx], &(*h)[idx])
		idx = parentIdx
		parentIdx = (idx - 1) / 2
	}
}

func (h *MinHeap) ExtractMin() (int, error) {

	if len(*h) == 0 {
		return -1, errors.New("The binary heap is empty.")
	}

	//The root is always the min
	min := (*h)[0]

	//Swap the root with the last element (bottommost-rightmost)
	swap(&(*h)[0], &(*h)[len(*h)-1])

	//Chop off the tail of the slice as we've already stored it in the var 'min'
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
		return boundaries && (*h)[idx] > (*h)[left] || (*h)[idx] > (*h)[right]
	}

	//Bubble down the root as long as one of its children is less than it
	for shouldBubbleDown() {

		//If the left child is less than the root, swap(root, left)
		if (*h)[left] <= (*h)[right] {
			swap(&(*h)[left], &(*h)[idx])
			idx = left
		} else {
			//If the right child is less than the root, swap(root, left)
			swap(&(*h)[right], &(*h)[idx])
			idx = right
		}
		left = (2 * idx) + 1
		right = (2 * idx) + 2
	}

	return min, nil
}

func swap(a *int, b *int) {
	var temp = *a
	*a = *b
	*b = temp
}
