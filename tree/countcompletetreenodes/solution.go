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

//https://leetcode.com/problems/count-complete-tree-nodes/
func main() {
	root := &TreeNode{Val: 1, Left: &TreeNode{Val: 2, Left: &TreeNode{Val: 4}, Right: &TreeNode{Val: 5}}, Right: &TreeNode{Val: 3, Left: &TreeNode{Val: 6}}}

	r := countNodes(root)
	fmt.Println(r)
}

func countNodes(root *TreeNode) int {
	if root == nil {
		return 0
	}
	var sum = 0

	left := getExtremeLeftDepth(root)
	right := getExtremeRightDepth(root)

	if left == right {
		for i := 0; i <= left; i++ {
			sum += PowInt(2, i)
		}

		return sum
	}

	l := countNodes(root.Left)
	r := countNodes(root.Right)

	return l + r + 1
}

func getExtremeLeftDepth(root *TreeNode) int {
	if root == nil {
		return -1
	}
	return getExtremeLeftDepth(root.Left) + 1
}

func getExtremeRightDepth(root *TreeNode) int {
	if root == nil {
		return -1
	}
	return getExtremeRightDepth(root.Right) + 1
}

func PowInt(x, power int) int {
	xFloat := float64(x)
	powerFloat := float64(power)
	return int(math.Pow(xFloat, powerFloat))
}
