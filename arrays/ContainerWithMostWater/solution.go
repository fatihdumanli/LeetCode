package main

import "fmt"

func main() {
	var height = []int{1, 8, 6, 2, 5, 4, 8, 3, 7}
	res := maxArea(height)
	fmt.Println(res)
}

func maxArea(height []int) int {
	maxArea := 0
	left := 0
	right := len(height) - 1

	for left < right {
		area := getArea(height[left], height[right], left, right)
		maxArea = Max(maxArea, area)

		if height[left] < height[right] {
			left++
		} else {
			right--
		}
	}

	return maxArea
}
func getArea(h1, h2, x1, x2 int) int {
	minHeight := Min(h1, h2)
	return minHeight * (x2 - x1)
}
func Min(a, b int) int {
	if a < b {
		return a
	}
	return b
}

func Max(a, b int) int {
	if a > b {
		return a
	}
	return b
}
