package main

import (
	"fmt"
	//mylist "github.com/fatihdumanli/mylist/list"
)

func main() {
	//list := mylist.New()
	//list.Add(12)
	//list.Add(13)
	//list.Add(14)
	//list.Add(15)
	//list.Add(16)
	//list.Add(16)
	//list.Add(16)
	//list.Add(16)

	sl := []int{1, 2, 3, 4}
	resize(sl)
	fmt.Println(sl)
}

func resize(slice []int) {
	newSlice := make([]int, 10, 10)
	slice = newSlice
}
