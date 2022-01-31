package main

import (
	"github.com/fatihdumanli/LeetCode/Implementations/LinkedList/linkedlist"
)

func main() {

	// 2 -> 1 -> 3
	var list = linkedlist.Constructor()
	list.AddAtHead(1)
	list.AddAtTail(3)
	list.AddAtIndex(3, 2)
}
