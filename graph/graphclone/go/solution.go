package main

import (
	"dsa"
	"fmt"
)

type Node = dsa.GraphNode

func main() {

	var one = &Node{Val: 1}
	var two = &Node{Val: 2}
	var three = &Node{Val: 3}
	var four = &Node{Val: 4}

	one.AddNeighbor(two, four)
	two.AddNeighbor(one, three)
	three.AddNeighbor(two, four)
	four.AddNeighbor(one, three)

	//TODO: File an issue on GitHub, it didn't get accepted even though the addresses are different.
	res := cloneGraph(one)
	fmt.Println(&one)
	fmt.Println(&res)
	fmt.Println((*res).Val)
}

func cloneGraph(node *Node) *Node {
	var hashset map[*Node]bool = make(map[*Node]bool, 0)
	return clone(node, hashset)
}

func clone(node *Node, hashset map[*Node]bool) *Node {
	var nodeVal = node.Val
	_ = nodeVal

	if hashset[node] {
		return node
	}

	var c = Node{Val: node.Val}
	hashset[node] = true

	for _, n := range node.Neighbors {
		c.Neighbors = append(n.Neighbors, clone(n, hashset))
	}
	return &c
}
