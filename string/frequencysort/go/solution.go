package main

import (
	"fmt"
	"math"
	"strings"
)

type heapType uint8

const (
        minheap heapType = iota
        maxheap
)

type heapNode struct {
        key int
        val int
}

type bheap struct {
        t          heapType
        values     []heapNode
        defaultVal int
}

func (bh *bheap) IsEmpty() bool {
	return len(bh.values) == 0
}

func (bh *bheap) Add(val heapNode) {
        bh.values = append(bh.values, val)

        var index = len(bh.values) - 1
        var parentIdx = (index - 1) / 2

        var shouldBubbleUp = func(pid int) bool {
                switch bh.t {
                case minheap:
                        return val.key < bh.values[pid].key
                case maxheap:
                        return val.key > bh.values[pid].key
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

func swap(a, b *heapNode) {
        var temp = *a
        *a = *b
        *b = temp
}

func (bh *bheap) Peek() heapNode {
        if len(bh.values) == 0 {
                return heapNode{key: bh.defaultVal}
        }

        return bh.values[0]
}

func (bh *bheap) Extract() heapNode {
        if len(bh.values) == 0 {
                return heapNode{key: bh.defaultVal}
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
                return bh.values[i].key
        }

        var getVal = func(i int) int {
                return bh.values[i].key
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

//https://leetcode.com/problems/sort-characters-by-frequency/
func main() {
	s := "tree"
	fmt.Println(frequencySort(s))
}

func frequencySort(s string) string {
	var freq map[int]int = make(map[int]int)
	
	for i := 0; i < len(s); i++ {
		var c = s[i]
		freq[int(c)]++
	}


	var heap = NewHeap(maxheap)
	for k, v := range freq {
		heapNode := heapNode{key: v, val: k}
		heap.Add(heapNode)
	}

	var sb strings.Builder
	for len(heap.values) > 1{

		v := heap.Extract()
		for i := 0; i < v.key; i++ {
			sb.WriteByte(byte(v.val))
		}
	}

	v := heap.Peek()
	for i := 0; i < v.key; i++ {
		sb.WriteByte(byte(v.val))
	}

	return sb.String()
}