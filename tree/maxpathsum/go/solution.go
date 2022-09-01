package main

import (
	"dsa"
	"fmt"
)

type TreeNode = dsa.TreeNode

func main() {
	var root = &TreeNode{Val: 9}
	root.AddLeftChild(6)

	root.AddRightChild(-3)
	root.Right.AddLeftChild(-6)

	root.Right.AddRightChild(2)
	root.Right.Right.AddLeftChild(2)

	root.Right.Right.Left.AddRightChild(-6)
	root.Right.Right.Left.AddLeftChild(-6)
	root.Right.Right.Left.Left.AddLeftChild(-6)

	res := maxPathSum(root)
	fmt.Println(res)
}

func maxPathSum(root *TreeNode) int {
	if root == nil {
		return 0
	}

	var max int = root.Val
	helper(root, &max)
	return max
}

func helper(root *TreeNode, max *int) int {
	if root == nil {
		return 0
	}

	left := helper(root.Left, max)
	right := helper(root.Right, max)

	var leftIncluded = left + root.Val
	var rightIncluded = right + root.Val
	var bothIncluded = right + left + root.Val

	*max = Max(*max, root.Val)
	*max = Max(*max, leftIncluded)
	*max = Max(*max, rightIncluded)
	*max = Max(*max, bothIncluded)

	var maxChild = Max(left, right)
	if maxChild < 0 {
		return root.Val
	}

	return Max(left, right) + root.Val
}

func Max(a, b int) int {
	if a > b {
		return a
	} else {
		return b
	}
}
