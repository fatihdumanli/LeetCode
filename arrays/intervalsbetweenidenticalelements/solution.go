package main

import "fmt"

//https://leetcode.com/problems/intervals-between-identical-elements/submissions/
func main() {
	arr := []int{2,1,3,1,2,3,3}
	r := getDistances(arr)
	fmt.Println(r)
}

func getDistances(arr []int) []int64 {
	var loc map[int]int = make(map[int]int)
	var sum map[int]int64 = make(map[int]int64)
	var freq map[int]int = make(map[int]int)

	var intervals []int64 = make([]int64, len(arr))

	for i := 0; i < len(arr); i++ {

		var num = arr[i]

		var newSum int64 = sum[num] + int64(freq[num]) * int64(AbsInt(i - loc[num]))
		intervals[i] = newSum

		sum[num] = newSum
		if _, ok := freq[num]; ok {
			freq[num]++
		} else {
			freq[num] = 1
		}
		loc[num] = i
	}
	// reset all the hashmaps here
	loc = make(map[int]int)
	sum = make(map[int]int64)
	freq = make(map[int]int)

	for i := len(arr) - 1; i >= 0; i-- {
		var num = arr[i]
		var newSum int64 = sum[num] + int64(freq[num]) * int64(AbsInt(i - loc[num]))

		sum[num] = newSum
		intervals[i] += newSum
		if _, ok := freq[num]; ok {
			freq[num]++
		} else {
			freq[num] = 1
		}
		loc[num] = i
	}

	return intervals
}

func AbsInt(x int) int {
	if x < 0 {
		return -x
	}
	return x
}