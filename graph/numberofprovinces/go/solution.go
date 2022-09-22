package main

import "fmt"

type listNode struct {
	val  int
	next *listNode
}

type queue struct {
	head *listNode
}

func (q *queue) enqueue(val int) {

	if q.head == nil {
		q.head = &listNode{val: val}
		return
	}

	newHead := &listNode{val: val}
	newHead.next = q.head
	q.head = newHead
}

func (q *queue) dequeue() int {
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

func main() {

	var isConnected = [][]int{}
	isConnected = append(isConnected, []int{1, 1, 0})
	isConnected = append(isConnected, []int{1, 1, 0})
	isConnected = append(isConnected, []int{0, 0, 1})

	var nProvinces = findCircleNum(isConnected)
	fmt.Println(nProvinces)
}

// [[1,1,0],[1,1,0],[0,0,1]]
func findCircleNum(isConnected [][]int) int {

	var n = len(isConnected)
	var neighbors map[int][]int = make(map[int][]int)

	/* BEGIN: Build the graph */
	for i := 0; i < n; i++ {
		neighbors[i] = []int{}
	}

	for i := 0; i < n; i++ {
		for j := 0; j < n; j++ {
			if i == j {
				continue
			}

			// city i has a connection to city j
			if isConnected[i][j] == 1 {
				neighbors[i] = append(neighbors[i], j)
			}
		}
	}
	/* END: Build the graph */

	//BFS
	var bfsQueue = queue{}
	var visited = make(map[int]bool)

	var answer = 0

	for i := 0; i < n; i++ {
		if _, ok := visited[i]; ok {
			continue
		}

		bfsQueue.enqueue(i)

		for !bfsQueue.isEmpty() {
			var dequeued = bfsQueue.dequeue()

			var edges = neighbors[dequeued]

			for _, e := range edges {
				if _, isVisited := visited[e]; !isVisited {
					bfsQueue.enqueue(e)
				}
			}

			visited[dequeued] = true

			if bfsQueue.isEmpty() {
				answer++
			}
		}
	}

	return answer
}
