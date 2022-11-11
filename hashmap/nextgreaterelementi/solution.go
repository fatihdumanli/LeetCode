package main

import (
	"fmt"
	"math"
)

func main() {
	nums1 := []int{1,3,5,2,4}
	nums2 := []int{6,5,4,3,2,1,7}
	r := nextGreaterElement(nums1, nums2)
	fmt.Println(r)
}

func pop(stack *[]int) int {
	if len(*stack) == 0 {
		return math.MaxInt32
	}

	var n = len(*stack) - 1
	var elm = (*stack)[n]
	*stack = (*stack)[:n]
	return elm
}

func top(stack *[]int) int {
	if len(*stack) == 0 {
		return math.MaxInt32
	}
	var n = len(*stack) - 1
	return (*stack)[n]
}

func nextGreaterElement(nums1 []int, nums2 []int) []int {
	var answer []int = make([]int, len(nums1))
	var stack []int
	var hashmap map[int]int = make(map[int]int)

	for i := len(nums2) - 1; i >= 0; i-- {
		if len(stack) == 0 {
			hashmap[nums2[i]] = -1
			stack = append(stack, nums2[i])
			continue
		}

		if top(&stack) > nums2[i] {
			hashmap[nums2[i]] = top(&stack)
			stack = append(stack, nums2[i])
			continue
		}

		//here the stack is not empty and 
		//the 'top' is less than the nums2[i]
		topElement := top(&stack)
		for topElement < nums2[i] {
			pop(&stack)
			topElement = top(&stack)
		}

		if topElement == math.MaxInt32 {
			hashmap[nums2[i]] = -1
			stack = append(stack, nums2[i])
			continue
		}

		hashmap[nums2[i]] = topElement
		stack = append(stack, nums2[i])
	}

	for i := 0; i < len(nums1); i++ {
		answer[i] = hashmap[nums1[i]]
	}

	return answer
}