package main

import (
	"dsa"
	"fmt"
)

func main() {
	var root = TreeNode{Val: 0}
	fmt.Println(isValidBST(&root))
}

type TreeNode = dsa.TreeNode

var lastValue *int

func isValidBST(root *TreeNode) bool {
	return checkIfValid(root)
}

func checkIfValid(node *TreeNode) bool {
	//in order traversal
	if node == nil {
		return true
	}

	l := checkIfValid(node.Left)
	if !l {
		return l
	}

	if lastValue != nil && node.Val <= *lastValue {
		return false
	}

	if lastValue == nil {
		lastValue = intp(node.Val)
	} else {
		*lastValue = node.Val
	}

	r := checkIfValid(node.Right)
	if !r {
		return r
	}
	return true
}

func intp(x int) *int {
	return &x
}
