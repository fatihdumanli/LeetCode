package main

import (
	"math"
)

//https://leetcode.com/problems/find-median-from-data-stream/
func main() {
	var mf = Constructor()
	mf.AddNum(4)
	mf.AddNum(11)
	mf.AddNum(7)
	mf.AddNum(17)
	mf.AddNum(9)
	mf.AddNum(2)

	//var heap = NewHeap(minheap)
	//heap.Add(9)
	//heap.Add(1)
	//heap.Add(0)
	//heap.Add(2)
	//fmt.Println(heap.Extract())
	//fmt.Println(heap.Extract())
	//fmt.Println(heap.Extract())
}

/* HEAP IMPLEMENTATION */
type heapType uint8

const (
	minheap heapType = iota
	maxheap
)

type bheap struct {
	t          heapType
	values     []int
	defaultVal int
}

func (bh *bheap) Add(val int) {
	bh.values = append(bh.values, val)

	var index = len(bh.values) - 1
	var parentIdx = (index - 1) / 2

	var shouldBubbleUp = func(pid int) bool {
		switch bh.t {
		case minheap:
			return val < bh.values[pid]
		case maxheap:
			return val > bh.values[pid]
		default:
			panic("err")
		}
	}

	for index > 0 && shouldBubbleUp(parentIdx) {
		swap(&bh.values[parentIdx], &bh.values[index])
		index = parentIdx
		parentIdx = (index - 1) / 2
	}

}

func swap(a, b *int) {
	var temp = *a
	*a = *b
	*b = temp
}

func (bh *bheap) Peek() int {
	if len(bh.values) == 0 {
		return bh.defaultVal
	}

	return bh.values[0]
}

func (bh *bheap) Extract() int {
	if len(bh.values) == 0 {
		return bh.defaultVal
	}

	var top = bh.values[0]

	bh.values[0] = bh.values[len(bh.values)-1]
	bh.values = bh.values[:len(bh.values)-1]

	var index = 0
	var isExist = func(i int) bool {
		return len(bh.values)-1 >= i
	}

	var getChildVal = func(i int) int {
		if !isExist(i) {
			return bh.defaultVal
		}
		return bh.values[i]
	}

	var getVal = func(i int) int {
		return bh.values[i]
	}

	var shouldBubbleDown = func(i int) bool {
		var left = 2*i + 1
		var right = 2*i + 2

		switch bh.t {
		case minheap:
			if getChildVal(left) < getVal(i) || getChildVal(right) < getVal(i) {
				return true
			}
		case maxheap:
			if getChildVal(left) > getVal(i) || getChildVal(right) > getVal(i) {
				return true
			}
		}
		return false
	}

	for shouldBubbleDown(index) {

		var left = 2*index + 1
		var right = 2*index + 2

		//which one to swap with?
		switch bh.t {
		case minheap:
			if getChildVal(left) < getChildVal(right) {
				//swap with left
				swap(&bh.values[index], &bh.values[left])
				index = left
			} else {
				//swap with right
				swap(&bh.values[index], &bh.values[right])
				index = right
			}
		case maxheap:
			if getChildVal(left) > getChildVal(right) {
				//swap with left
				swap(&bh.values[index], &bh.values[left])
				index = left
			} else {
				//swap with right
				swap(&bh.values[index], &bh.values[right])
				index = right
			}
		}

	}

	return top
}

func NewHeap(t heapType) *bheap {

	var defVal int

	switch t {
	case minheap:
		defVal = math.MaxInt32
	case maxheap:
		defVal = math.MinInt32
	}

	return &bheap{
		t:          t,
		defaultVal: defVal,
	}
}

/* HEAP IMPLEMENTATION */
type MedianFinder struct {
	leftHeap  *bheap
	rightHeap *bheap
}

func Constructor() MedianFinder {
	return MedianFinder{
		leftHeap:  NewHeap(maxheap),
		rightHeap: NewHeap(minheap),
	}
}

func (this *MedianFinder) AddNum(num int) {

	//very first insertion
	if len(this.leftHeap.values) == 0 {
		this.leftHeap.Add(num)
		return
	}

	var leftHeapVals = this.leftHeap.values
	_ = leftHeapVals
	var rightHeapVals = this.rightHeap.values
	_ = rightHeapVals
	//1. DETERMINE THE HEAP.
	var heapToAdd *bheap

	//if the number is less than max of left heap
	if num < this.leftHeap.Peek() {
		heapToAdd = this.leftHeap
		//need to add the number to the LEFT heap
	} else {
		//need to add the number to the RIGHT heap
		heapToAdd = this.rightHeap
	}

	//2. CHECK IF THE INSERTION WILL LEAD TO A STATE OF IMBALANCE
	var absInt = func(a, b int) int {
		if a > b {
			return a - b
		} else if b > a {
			return b - a
		} else {
			return 0
		}
	}

	var checkImbalance = func() bool {
		return absInt(len(this.leftHeap.values), len(this.rightHeap.values)) > 1
	}

	heapToAdd.Add(num)
	if checkImbalance() {
		if len(this.leftHeap.values) > len(this.rightHeap.values) {
			this.rightHeap.Add(this.leftHeap.Extract())
		} else {
			this.leftHeap.Add(this.rightHeap.Extract())
		}
	}

}

func (this *MedianFinder) FindMedian() float64 {

	l := len(this.leftHeap.values) + len(this.rightHeap.values)

	if l%2 == 0 {
		var leftMax = this.leftHeap.Peek()
		var rightMin = this.rightHeap.Peek()
		var sum = float64(leftMax) + float64(rightMin)
		return sum / 2
	} else {
		if len(this.leftHeap.values) > len(this.rightHeap.values) {
			return float64(this.leftHeap.Peek())
		} else {
			return float64(this.rightHeap.Peek())
		}
	}
}
