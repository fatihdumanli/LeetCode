package main

import "fmt"

func main() {
	fmt.Println(countBits(10))
}

func countBits(n int) []int {
	var result []int
	result = make([]int, n+1)

	for i := 1; i <= n; i++ {
		numOfBits := getNumberOfBits(i)
		result[i] = numOfBits
	}

	return result
}

func getNumberOfBits(num int) int {

	var count int
	for num > 0 {
		count += num & 1
		num >>= 1
	}

	return count
}
