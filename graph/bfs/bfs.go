package main

import (
	"dsa"
	"fmt"
)

type ListNode = dsa.ListNode

func addEdge(adjList map[int]*ListNode, from int, to int) {
	neighborsHead := adjList[from]

	if neighborsHead == nil {
		adjList[from] = &ListNode{
			Val: to,
		}
		return
	}

	for neighborsHead.Next != nil {
		neighborsHead = neighborsHead.Next
	}

	neighborsHead.Next = &ListNode{Val: to}
}

func main() {

	var adjList map[int]*ListNode
	adjList = make(map[int]*ListNode, 0)

	//	var nodes = []int{1,2,3,4,5}
	addEdge(adjList, 1, 4)
	addEdge(adjList, 1, 2)
	addEdge(adjList, 1, 3)
	addEdge(adjList, 1, 5)
	addEdge(adjList, 4, 7)
	addEdge(adjList, 7, 9)
	addEdge(adjList, 9, 11)
	addEdge(adjList, 3, 9)
	addEdge(adjList, 3, 11)
	printGraph(adjList)

	bfs(&adjList)

	//	printGraph(adjList)
}

func enqueue(q *[]int, val int) {
	(*q) = append(*q, val)
}

func dequeue(q *[]int) int {
	first := (*q)[0]
	(*q) = (*q)[1:]
	return first
}

func bfs(adjList *map[int]*ListNode) {
	var queue = &[]int{}

	var firstNode = 1
	enqueue(queue, firstNode)

	var visited = make([]bool, 12)

	for len(*queue) > 0 {
		node := dequeue(queue)

		fmt.Println("visiting ", node)

		var neighborList = (*adjList)[node]

		for neighborList != nil {
			if !visited[neighborList.Val] {
				enqueue(queue, neighborList.Val)
			}

			neighborList = neighborList.Next
		}
		visited[node] = true
		fmt.Println("visited ", node)
	}
}

func printGraph(adjList map[int]*ListNode) {
	for k, v := range adjList {
		fmt.Println("node ", k)

		ptr := v

		fmt.Println("neighbors")
		for ptr != nil {
			fmt.Println(ptr.Val)
			ptr = ptr.Next
		}
	}

}
