package main

import (
	"fmt"
	"math"
)

type TreeNode struct {
	Val   int
	Left  *TreeNode
	Right *TreeNode
}

func main() {
	root := &TreeNode{Val: 1, Left: &TreeNode{Val: 2}, Right: &TreeNode{Val: 3}}
	r := minDepth(root)
	fmt.Println(r)
}

func minDepth(root *TreeNode) int {
	if root == nil {
		return 0
	}

	return helper(root, 1)
}

func helper(root *TreeNode, level int) int {
	if root == nil {
		return math.MaxInt32
	}

	if root.Left == nil && root.Right == nil {
		return level
	}

	return Min(helper(root.Left, level+1), helper(root.Right, level+1))
}

func Min(a, b int) int {
	if a < b {
		return a
	}
	return b
}
