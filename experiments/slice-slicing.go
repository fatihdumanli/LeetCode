package main

import (
	"fmt"
	"time"
)

func main() {

	var slice []int

	for i := 0; i < 10_000; i++ {
		slice = append(slice, i)
	}

	now := time.Now()
	part := slice[1000:4345]
	_ = part
	elapsed := time.Since(now)
	fmt.Println(elapsed)
	now = time.Now()
	slice = part
	elapsed = time.Since(now)
	fmt.Println(elapsed)
	fmt.Println(slice)

}
