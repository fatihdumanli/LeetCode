package main

import (
	"dsa"
	"fmt"
	"math"
)

type TreeNode = dsa.TreeNode

func main() {
	var root = TreeNode{Val: 4}
	root.AddLeftChild(3)
	root.Left.AddLeftChild(1)
	root.AddRightChild(7)
	res := isBalanced(&root)
	fmt.Println(res)
}

func isBalanced(root *TreeNode) bool {
	_, res := checkBalanced(root)
	return res
}

func checkBalanced(node *TreeNode) (int, bool) {
	if node == nil {
		return 1, true
	}
	l, ok := checkBalanced(node.Left)
	if !ok {
		return 0, false
	}
	r, ok := checkBalanced(node.Right)
	if !ok {
		return 0, false
	}
	if math.Abs(float64(l)-float64(r)) > 1 {
		return 0, false
	}
	return Max(l, r) + 1, true
}

func Max(a, b int) int {
	if a > b {
		return a
	} else {
		return b
	}
}
