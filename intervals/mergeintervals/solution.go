package main

import "fmt"

func main() {
	//var intervals [][]int = make([][]int, 4)
	//intervals[0] = []int{1, 3}
	//intervals[1] = []int{2, 6}
	//intervals[2] = []int{8, 10}
	//intervals[3] = []int{15, 18}

	//var intervals [][]int = make([][]int, 2)
	//intervals[0] = []int{1, 4}
	//intervals[1] = []int{1, 4}

	var intervals [][]int = make([][]int, 3)
	intervals[0] = []int{1, 4}
	intervals[1] = []int{0, 2}
	intervals[2] = []int{3, 5}

	//var intervals [][]int = make([][]int, 5)
	//intervals[0] = []int{2, 3}
	//intervals[1] = []int{4, 5}
	//intervals[2] = []int{6, 7}
	//intervals[3] = []int{8, 9}
	//intervals[4] = []int{1, 10}

	result := merge(intervals)
	fmt.Println(result)
}

func merge(intervals [][]int) [][]int {

	var result [][]int
	for i := 0; i < len(intervals); i++ {

		if intervals[i] == nil {
			continue
		}

		for j := 0; j < len(intervals); j++ {

			if i == j {
				continue
			}

			if intervals[j] == nil {
				continue
			}

			if isBetween(intervals[i][0], intervals[j][0], intervals[j][1]) {
				merged := mergeIntervals(intervals[i], intervals[j])
				intervals[i] = merged
				intervals[j] = nil
				continue
			}

			if isBetween(intervals[j][0], intervals[i][0], intervals[i][1]) {
				merged := mergeIntervals(intervals[i], intervals[j])
				intervals[i] = merged
				intervals[j] = nil
				continue

			}

		}
	}

	for i := 0; i < len(intervals); i++ {
		if intervals[i] != nil {
			result = append(result, intervals[i])
		}
	}

	return result
}

func mergeIntervals(a, b []int) []int {
	var minStart = Min(a[0], b[0])
	var maxEnd = Max(a[1], b[1])

	return []int{minStart, maxEnd}
}

func isBetween(x, start, end int) bool {
	return x >= start && x <= end
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
