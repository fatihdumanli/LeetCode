package main

import (
	"fmt"
	"sort"
)

//https://leetcode.com/problems/non-overlapping-intervals/
func main() {
	intervals := [][]int{{-52,31},{-73, -26},{82,97},{-65, -11},{-62, -49},{95,99},
		{58,95},{-31,49},{66,98},{-63,2},{30,47},{-40,-26}}
	//intervals := [][]int{{1,2},{2,4},{3,6},{4,5}}
	r := eraseOverlapIntervals(intervals)
	fmt.Println(r)
}

func eraseOverlapIntervals(intervals [][]int) int {
	if len(intervals) <= 1 {
		return 0
	}

	sort.Slice(intervals, func(i, j int) bool {
		return intervals[i][0] < intervals[j][0]
	})

	var cnt = 0
	var lastAdj = 0
	for i := 1; i < len(intervals); i++ {

		// if the current one starts before the prev adj ends
		if intervals[i][0] < intervals[lastAdj][1] {
			//we're gonna remove an interval for sure,
			//the question is which one?
			//if the current ends last
			if intervals[i][1] > intervals[lastAdj][1] {
				//we gotta remove the current one as this is the one has a further reach (it's more likely to cause overlap)
				// |-----------|
				//    |----------------| (i) --> remove this as this one is more likely to cause overlap
				// we do that by not modifiying the lastAdj, and increasing the cnt
			} else {
				//if the current one ends fist (intervals[i][1] < intervals[lastAdj][1])
				// |---------------------| (lastAdj) --> remove this
				//     |---------|
				// we gotta remove the previous one as it's more likely to cause an overlap
				// we do that by settings lastAdj = i
				lastAdj = i
			} 
			cnt++
		} else {
			lastAdj = i
		}
	}

	return cnt
}