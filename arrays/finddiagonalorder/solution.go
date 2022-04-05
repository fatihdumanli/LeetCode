package main

import "fmt"

func main() {
	var nums [][]int = make([][]int, 5)
	nums[0] = []int{1, 2, 3, 4, 5}
	nums[1] = []int{6, 7}
	nums[2] = []int{8}
	nums[3] = []int{9, 10, 11}
	nums[4] = []int{12, 13, 14, 15, 16}
	fmt.Println(findDiagonalOrder(nums))
}

func findDiagonalOrder(nums [][]int) []int {
	var traverse []int
	var hashmap map[int][]int = make(map[int][]int)
	var maxkey int

	for i := len(nums) - 1; i >= 0; i-- {
		var cur = nums[i]
		for j := 0; j < len(cur); j++ {
			if _, ok := hashmap[i+j]; !ok {
				hashmap[i+j] = []int{nums[i][j]}
			} else {
				hashmap[i+j] = append(hashmap[i+j], nums[i][j])
			}
			maxkey = Max(maxkey, i+j)
		}
	}

	for i := 0; i <= maxkey; i++ {
		var vals = hashmap[i]
		for j := 0; j < len(vals); j++ {
			traverse = append(traverse, vals[j])
		}
	}

	return traverse
}

func Max(a, b int) int {
	if a > b {
		return a
	}
	return b
}
