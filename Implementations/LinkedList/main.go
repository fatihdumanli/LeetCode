package main

import (
	"fmt"

	"github.com/fatihdumanli/LeetCode/Implementations/LinkedList/linkedlist"
)

func main() {

	// 2 -> 1 -> 3
	var myList = linkedlist.Constructor()
	fmt.Println(myList.Get(0))
}
