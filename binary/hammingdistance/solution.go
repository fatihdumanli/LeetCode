package main

import "fmt"

func main() {
	fmt.Println(hammingDistance(1, 4))
}

func hammingDistance(x int, y int) int {
	count := 0
	for x > 0 || y > 0 {
		a := x & 1
		b := y & 1
		count += a ^ b
		x >>= 1
		y >>= 1
	}
	return count
}
