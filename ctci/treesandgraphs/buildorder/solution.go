package main

import (
	"fmt"
)

type ListNode struct {
	Val  string
	Next *ListNode
}

func main() {

	var projects = []string{"a", "b", "c", "d", "e", "f", "g"}
	var deplist = [][2]string{
		{"f", "c"},
		{"f", "b"},
		{"f", "a"},
		{"c", "a"},
		{"b", "a"},
		{"b", "e"},
		{"a", "e"},
		{"d", "g"},
	}

	/*
		Adj list

		f -> c, b, a
		c -> a
		b -> a, e
		a -> e
		d -> g
	*/

	//res := buildOrder(projects, deplist)
	res := buildOrderDfs(projects, deplist)
	fmt.Println(res)

}

//NOTE
//DFS
var orderedList = &ListNode{Val: ""}

func buildOrderDfs(projects []string, deplist [][2]string) []string {
	var result []string
	var graph = buildGraph(projects, deplist)

	//0: not visited
	//1: visiting
	//2: visited
	visited := make(map[string]int, 0)
	for k := range graph {
		visited[k] = 0
	}

	for node := range graph {
		if visited[node] == 0 {
			dfs(graph, node, visited)
		}
	}

	var ptr *ListNode
	ptr = orderedList.Next

	for ptr != nil {
		result = append(result, ptr.Val)
		ptr = ptr.Next
	}

	return result
}

func dfs(adjList map[string][]string, node string, visited map[string]int) {
	neighbors, ok := adjList[node]
	if !ok {
		panic("there's no such a node")
	}

	visited[node] = 1
	for _, neighbor := range neighbors {
		if visited[neighbor] == 1 {
			panic("there's a circular dependency")
		}

		if visited[neighbor] == 0 {
			dfs(adjList, neighbor, visited)
		}

	}

	//NOTE
	//No matter which node we're performing DFS on, we should always add the current element to the head
	//Because higher level nodes must be built first no matter what
	newHead := &ListNode{Val: node}
	newHead.Next = orderedList
	orderedList = newHead

	visited[node] = 2

}

//NOTE
//Topological sort
//1: Find the nodes without incoming edges (Projects that can be build immediately)
//2: Remove the nodes that you've grabbed at step 1 from the graph. Don't forget to add them to the ordered list first
//3: Repeat these steps as long as there's at least 1 node without incoming edge in the graph
//If there's no node left without incoming edges in the graph and the len(ordered list) is still les than len(projects)
//That would mean there's a dependency cycle, simply return an error code.
func buildOrder(projects []string, deplist [][2]string) []string {
	var result []string

	var graph = buildGraph(projects, deplist)
	var nodes = findNodesWithoutIncomingEdges(graph)
	var numOfNodesWithoutIncomingEdges = len(nodes)
	for numOfNodesWithoutIncomingEdges > 0 {
		result = append(result, nodes...)
		//removeOutgoingEdges(graph, nodes...)
		removeNode(graph, nodes...)
		nodes = findNodesWithoutIncomingEdges(graph)
		numOfNodesWithoutIncomingEdges = len(nodes)
	}
	if len(result) < len(projects) {
		panic("There's a dependency cycle!")
	}

	return result
}

func removeNode(adjList map[string][]string, node ...string) {
	for _, s := range node {
		delete(adjList, s)
	}
}

func findNodesWithoutIncomingEdges(adjList map[string][]string) []string {
	var nodes []string
	var incomingEdges map[string]int
	incomingEdges = make(map[string]int, 0)

	for k := range adjList {
		incomingEdges[k] = 0
	}

	for _, v := range adjList {
		for _, n := range v {
			incomingEdges[n]++
		}
	}

	for k, v := range incomingEdges {
		if v == 0 {
			nodes = append(nodes, k)
		}
	}

	return nodes
}

func buildGraph(projects []string, deplist [][2]string) map[string][]string {
	//adj list
	var graph map[string][]string
	graph = make(map[string][]string, 0)
	//Adding nodes to the adj lsit
	for _, p := range projects {
		graph[p] = []string{}
	}
	//Populating the neighbors
	for _, d := range deplist {
		graph[d[0]] = append(graph[d[0]], d[1])
	}
	return graph
}
