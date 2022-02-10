package main

import (
	"dsa"
	"fmt"
)

type TreeNode = dsa.TreeNode

func main() {
	var root = &TreeNode{Val: 3}
	root.AddLeftChild(5)
	root.AddRightChild(4)
	root.Right.AddRightChild(1)
	root.Left.AddRightChild(-1)
	root.Left.Right.AddLeftChild(4)
	root.Left.Right.Left.AddRightChild(5)
	root.Right.AddLeftChild(-1)
	root.Right.Right.AddLeftChild(-4)
	root.Right.Left.AddLeftChild(3)
	root.Right.Left.Left.AddRightChild(2)
	fmt.Println(numOfPaths(root, 8))
}

func numOfPaths(root *TreeNode, target int) int {
	var result int
	helper(root, 0, target, &result)
	return result
}

func helper(root *TreeNode, sum int, target int, result *int) {
	if root == nil {
		return
	}

	sum += root.Val
	if sum == target {
		*result++
	}

	helper(root.Left, sum, target, result)
	helper(root.Left, 0, target, result)
	helper(root.Right, sum, target, result)
	helper(root.Right, 0, target, result)
}
