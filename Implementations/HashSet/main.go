package main

import (
	"fmt"

	"github.com/fatihdumanli/LeetCode/Implementations/HashSet/hashset"
)

func main() {
	set := hashset.Constructor()

	set.Add(2)
	set.Add(2)
	set.Add(2)
	set.Add(5)
	set.Add(4)
	set.Add(3)
	set.Add(3)
	set.Add(3)
	set.Add(3)
	set.Add(3)
	set.Remove(3)
	set.Remove(2)
	fmt.Println(set.Contains(3))
	fmt.Println(set.Contains(2))

}
