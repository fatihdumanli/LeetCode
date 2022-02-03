package main

import (
	"fmt"
	"time"
)

func main() {
	var arr = make([]int, 0, 0)

	for i := 0; i < 509; i++ {
		arr = append(arr, i)
	}

	fmt.Println(len(arr))
	fmt.Println(cap(arr))

	now := time.Now()
	arr = append(arr, 1)
	d1 := time.Since(now)
	arr = append(arr, 2)
	d2 := time.Since(now)
	arr = append(arr, 3)
	d3 := time.Since(now)
	arr = append(arr, 4)
	d4 := time.Since(now)
	fmt.Println(d1, d2, d3, d4)

}
