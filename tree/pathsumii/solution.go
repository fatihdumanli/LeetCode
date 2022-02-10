package main

import (
	"dsa"
	"fmt"
)

type TreeNode = dsa.TreeNode

//https://leetcode.com/problems/path-sum-ii/
func main() {

	var root = &TreeNode{Val: 5}
	root.AddLeftChild(4)
	root.AddRightChild(8)
	root.Left.AddLeftChild(11)
	root.Right.AddLeftChild(13)
	root.Right.AddRightChild(4)
	root.Left.Left.AddRightChild(2)
	root.Left.Left.AddLeftChild(7)
	root.Right.Right.AddLeftChild(5)
	root.Right.Right.AddRightChild(1)
	fmt.Println(pathSum(root, 22))
}

func pathSum(root *TreeNode, targetSum int) [][]int {
	var result [][]int
	helper(root, []int{}, targetSum, &result)

	fmt.Println(result)
	return result
}

func helper(root *TreeNode, thread []int, sum int, result *[][]int) {
	if root == nil {
		return
	}

	thread = append(thread, root.Val)
	sum -= root.Val

	if sum == 0 && root.Left == nil && root.Right == nil {

		var buffer = make([]int, len(thread))
		for i := 0; i < len(thread); i++ {
			buffer[i] = thread[i]
		}
		*result = append(*result, buffer)
	}

	helper(root.Left, thread, sum, result)
	helper(root.Right, thread, sum, result)
}
