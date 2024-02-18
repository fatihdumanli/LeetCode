package main

import "fmt"

func main() {
    heights := []int{1,2}
    var bricks = 0
    var ladders = 0

    r := furthestBuilding(heights, bricks, ladders)
    fmt.Println(r)
}

type MaxHeap struct {
	array []int
        Len int
}

func (h *MaxHeap) Insert(key int) {
	h.array = append(h.array, key)
        h.Len++
	h.maxHeapifyUp(len(h.array) - 1)
}

func (h *MaxHeap) Peek() int {
    return h.array[0]
}

func (h *MaxHeap) Extract() int {
	extracted := h.array[0]
	l := len(h.array) - 1
        h.Len--

	if len(h.array) == 0 {
		fmt.Println("Cannot extract because array lenth is 0")
		return -1
	}
	h.array[0] = h.array[l]
	h.array = h.array[:l]

	h.maxHeapifyDown(0)
	return extracted
}

func (h *MaxHeap) maxHeapifyUp(index int) {
	for h.array[parent(index)] < h.array[index] {
		h.swap(parent(index), index)
		index = parent(index)
	}
}

func (h *MaxHeap) maxHeapifyDown(index int) {
	lastIndex := len(h.array) - 1
	l, r := left(index), right(index)
	childToCompare := 0
	for l <= lastIndex { 
		if l == lastIndex {
			childToCompare = l
		} else if h.array[l] > h.array[r] {
			childToCompare = l
		} else { 
			childToCompare = r
		}
		if h.array[index] < h.array[childToCompare] {
			h.swap((index), childToCompare)
			index = childToCompare
			l, r = left(index), right(index)
		} else {
			return
		}
	}
}

func parent(i int) int {
	return (i - 1) / 2
}

func left(i int) int {
	return 2*i + 1
}

func right(i int) int {
	return 2*i + 2
}

func (h *MaxHeap) swap(i1, i2 int) {
	h.array[i1], h.array[i2] = h.array[i2], h.array[i1]
}

// https://leetcode.com/problems/furthest-building-you-can-reach
func furthestBuilding(heights []int, bricks int, ladders int) int {

    maxHeap := MaxHeap{}

    for i := 0; i < len(heights) - 1; i++ {
        var curHeight = heights[i]
        var nextHeight = heights[i + 1]

        if nextHeight <= curHeight {
            continue
        }

        var diff = nextHeight - curHeight

        // can we use bricks?
        if diff <= bricks {
            bricks -= diff
            maxHeap.Insert(diff)
            continue
        }

        // there's no enough bricks
        // see if using a ladder for a previous jump would help
        // it helps

        // NOTE: Only use if the Peek() is greater than the current jump,
        // otherwise, use ladder

        // Why would we use a ladder for a previous jump if it's less than the
        // current one?
        if maxHeap.Len > 0 && bricks + maxHeap.Peek() >= diff && ladders > 0 && maxHeap.Peek() > diff {
            var maxJump = maxHeap.Extract()
            bricks += maxJump
            bricks -= diff
            maxHeap.Insert(diff)
            ladders--
            continue
        }

        // it doesn't help, see if we have any ladder
        if ladders >= 1 {
            ladders--
            continue
        } else { 
            //we don't have any ladder
            // that's furthest point we can reach
            return i
        }
    }

    // we made it to the last building
    return len(heights) - 1
}
    



