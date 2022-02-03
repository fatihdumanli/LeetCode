package main

import "fmt"

func main() {
	var arr = make([]int, 0, 0)

	arr = append(arr, 1)
	arr = append(arr, 2)
	arr = append(arr, 3)
	fmt.Println(len(arr), cap(arr))

	arr = arr[:len(arr)-1]
	fmt.Println(len(arr), cap(arr))

}
