package main

import (
	"dsa"
	"fmt"
)

type TreeNode = dsa.TreeNode

func main() {
	var root = &TreeNode{Val: 1}
	root.AddLeftChild(2)

	fmt.Println(hasPathSum(root, 3))
}

func hasPathSum(root *TreeNode, targetSum int) bool {
	if root == nil {
		return false
	}

	var left = hasPathSum(root.Left, targetSum-root.Val)
	if left {
		return true
	}
	var right = hasPathSum(root.Right, targetSum-root.Val)
	if targetSum == root.Val {
		return true && (root.Left == nil && root.Right == nil) //is leaf
	}
	if right {
		return true
	}

	return false
}
