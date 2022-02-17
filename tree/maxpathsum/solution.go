package main

import (
	"dsa"
	"fmt"
)

type TreeNode = dsa.TreeNode

func main() {
	var root = &TreeNode{Val: -10}

	root.AddLeftChild(9)
	root.AddRightChild(20)
	root.Right.AddLeftChild(15)
	root.Left.AddLeftChild(20)
	root.Left.AddRightChild(40)

	res := maxPathSum(root)
	fmt.Println(res)
}

func maxPathSum(root *TreeNode) int {
	if root == nil {
		return 0
	}

	var rootVal = root.Val
	_ = rootVal

	var leftRes = maxPathSum(root.Left)
	var rightRes = maxPathSum(root.Right)

	_ = leftRes
	_ = rightRes

	res := helper(root, 0)
	_ = res
	greaterPath := Max(leftRes, rightRes)
	totalPath := leftRes + rightRes + root.Val

	return Max(greaterPath, totalPath)

}

func helper(root *TreeNode, sum int) int {
	if root == nil {
		return 0
	}

	var rootVal = root.Val
	_ = rootVal

	sum = sum + root.Val
	r := helper(root.Left, sum)
	l := helper(root.Right, sum)

	max := Max(r, l)

	return max + root.Val
}

func Max(a, b int) int {
	if a > b {
		return a
	} else {
		return b
	}
}
