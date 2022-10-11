package main

import "fmt"

func main() {
	nums := []int{0, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 0, 1, 0, 1, 0}
	r := findMaxLength(nums)
	fmt.Println(r)
}

func findMaxLength(nums []int) int {
	var sumMap map[int]int = make(map[int]int, len(nums))
	var max = 0
	var sum = 0

	sumMap[0] = -1
	for i := 0; i < len(nums); i++ {
		if nums[i] == 0 {
			sum -= 1
		} else {
			sum += 1
		}

		if _, ok := sumMap[sum]; ok || sum == 0 {
			max = Max(max, i-sumMap[sum])
		} else {
			sumMap[sum] = i
		}
	}

	return max
}

func Max(a, b int) int {
	if a > b {
		return a
	}
	return b
}
