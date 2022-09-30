package main

import (
	"fmt"
	"math"
)

func main() {
	n := 2
	times := [][]int{{1, 2, 1}, {2, 1, 3}}
	k := 3

	r := networkDelayTime(times, n, k)
	fmt.Println(r)
}

type listNode struct {
	val  [2]int
	next *listNode
}

type queue struct {
	head *listNode
}

func (q *queue) enqueue(val [2]int) {
	if q.head == nil {
		q.head = &listNode{val: val}
		return
	}

	var ptr = q.head

	for ptr.next != nil {
		ptr = ptr.next
	}

	ptr.next = &listNode{val: val}
}

func (q *queue) dequeue() [2]int {
	if q.head == nil {
		panic("the queue is empty")
	}

	var val = q.head.val

	q.head = q.head.next
	return val
}

func (q *queue) isEmpty() bool {
	return q.head == nil
}
func networkDelayTime(times [][]int, n int, k int) int {

	var adjList map[int][][]int = make(map[int][][]int)

	for _, v := range times {
		adjList[v[0]] = append(adjList[v[0]], []int{v[1], v[2]})
	}

	minLatencyMap := bfs(adjList, n, k)

	var max int = math.MinInt32

	for i, v := range minLatencyMap {

		if i == k {
			continue
		}

		if v > max {
			max = v
		}

		if v == math.MaxInt32 {
			return -1
		}
	}

	return max
}

func bfs(adjList map[int][][]int, n int, start int) map[int]int {
	var minLatencyMap map[int]int = make(map[int]int, n)

	for i := 1; i <= n; i++ {
		minLatencyMap[i] = math.MaxInt32
	}

	bfsQueue := queue{}
	bfsQueue.enqueue([2]int{start, 0})

	for !bfsQueue.isEmpty() {

		dequeued := bfsQueue.dequeue()

		dequeuedNode := dequeued[0]
		latencySoFar := dequeued[1]

		minLatencyMap[dequeuedNode] = min(minLatencyMap[dequeuedNode], latencySoFar)
		var edges = adjList[dequeuedNode]

		for _, e := range edges {

			nodeToEnqueue := e[0]
			newLatency := latencySoFar + e[1]

			if minLatencyMap[nodeToEnqueue] <= newLatency {
				continue
			}

			bfsQueue.enqueue([2]int{nodeToEnqueue, newLatency})
		}
	}

	return minLatencyMap
}

func min(a, b int) int {
	if a < b {
		return a
	}
	return b
}
