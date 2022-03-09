package main

import (
	"fmt"
	"math"
)

func main() {

	var mf = Constructor()
	mf.AddNum(4)
	mf.AddNum(5)
	mf.AddNum(1)

	fmt.Println(mf.FindMedian())
}

type listNode struct {
	val  int
	next *listNode
}
type MedianFinder struct {
	n     int
	head  *listNode
	cache map[int]float64
}

func Constructor() MedianFinder {
	head := &listNode{val: math.MinInt32}
	return MedianFinder{
		head:  head,
		cache: make(map[int]float64),
	}
}

func (this *MedianFinder) AddNum(num int) {
	var ptr = this.head

	for ptr.next != nil && num > ptr.next.val {
		ptr = ptr.next
	}

	var temp = ptr.next
	ptr.next = &listNode{val: num, next: temp}
	this.n++
}

func (this *MedianFinder) FindMedian() float64 {

	if this.cache[this.n] != 0 {
		return this.cache[this.n]
	}

	var ptr = this.head.next

	if this.n == 1 {
		this.cache[1] = float64(ptr.val)
		return float64(ptr.val)
	}

	if this.n == 2 {
		this.cache[2] = (float64(ptr.val) + float64(ptr.next.val)) / 2
		return this.cache[2]
	}

	if this.n%2 == 0 {
		for i := 0; i < this.n/2-1; i++ {
			ptr = ptr.next
		}
		var sum = float64(ptr.val) + float64(ptr.next.val)

		this.cache[this.n] = float64(sum / 2)
		return this.cache[this.n]
	} else {
		for i := 0; i < this.n/2; i++ {
			ptr = ptr.next
		}
		this.cache[this.n] = float64(ptr.val)
		return this.cache[this.n]
	}
}
