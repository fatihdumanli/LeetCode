package main

//https://leetcode.com/problems/range-sum-query-immutable
type NumArray struct {
	presum []int
}

func Constructor(nums []int) NumArray {
	var presum = make([]int, len(nums)+1)

	var sum = 0
	for i := 0; i < len(nums); i++ {
		sum += nums[i]
		presum[i+1] = sum
	}

	return NumArray{
		presum: presum,
	}
}

func (this *NumArray) SumRange(left int, right int) int {
	left++
	right++
	return this.presum[right] - this.presum[left-1]
}
