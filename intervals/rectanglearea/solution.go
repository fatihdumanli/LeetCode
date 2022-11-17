package main

import "fmt"

//https://leetcode.com/problems/rectangle-area/
func main() {
	r := computeArea(-3, 0, 3, 4, 0, -1, 9, 2)
	fmt.Println(r)
}

func computeArea(ax1 int, ay1 int, ax2 int, ay2 int, bx1 int, by1 int, bx2 int, by2 int) int {

	var firstArea = (ax2 - ax1) * (ay2 - ay1)
	var secondArea = (bx2 - bx1) * (by2 - by1)

	var xOverlap = Min(ax2, bx2) - Max(ax1, bx1)
	var yOverlap = Min(ay2, by2) - Max(ay1, by1)

	var overlapArea int = 0

	if xOverlap > 0 && yOverlap > 0 {
		overlapArea = xOverlap * yOverlap
	}

	return (firstArea + secondArea) - overlapArea
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
