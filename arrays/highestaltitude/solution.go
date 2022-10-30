package main

import "fmt"

//https://leetcode.com/problems/find-the-highest-altitude/
func main() {
	gain := []int{-5, 1, 5, 0, -7}
	r := largestAltitude(gain)
	fmt.Println(r)
}

func largestAltitude(gain []int) int {
	max := 0
	s := 0

	for i := 0; i < len(gain); i++ {
		s += gain[i]
		max = Max(max, s)
	}
	return max
}

func Max(a, b int) int {
	if a > b {
		return a
	}
	return b
}
