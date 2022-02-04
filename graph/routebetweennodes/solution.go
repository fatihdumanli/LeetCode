package main

import (
	"dsa"
	"fmt"
)

type GraphNode = dsa.GraphNode

//Given a directed graph and two nodes (S and E), design an algorithm to find out whether there is a route from S to E
func main() {
	var one = dsa.NewGraphNode(1)
	var two = dsa.NewGraphNode(2)
	var three = dsa.NewGraphNode(3)
	var four = dsa.NewGraphNode(4)
	var five = dsa.NewGraphNode(5)
	var six = dsa.NewGraphNode(6)
	var seven = dsa.NewGraphNode(7)

	one.AddNeighbor(seven, two)
	three.AddNeighbor(six)
	five.AddNeighbor(six)
	seven.AddNeighbor(three, five, six)
	_ = four

	res := findRoute(three, six)
	fmt.Println(res)

}

func findRoute(s, e *GraphNode) bool {

	var queue = dsa.NewQueue()
	var visited = make(map[*GraphNode]bool, 10)

	queue.Enqueue(s)

	for !queue.IsEmpty() {
		var dequeued, _ = queue.Dequeue()
		var node = dequeued.(*GraphNode)

		for _, n := range node.Neighbors {
			if !visited[n] {
				queue.Enqueue(n)
			}
		}
		visited[node] = true
	}

	return visited[e]
}
