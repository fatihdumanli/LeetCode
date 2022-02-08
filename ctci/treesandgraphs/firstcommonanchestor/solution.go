package main

import (
	"dsa"
	"fmt"
)

type TreeNode = dsa.TreeNode

func main() {

	var root = &TreeNode{Val: -1}
	root.AddLeftChild(0)
	root.Left.AddLeftChild(-2)
	root.Left.Left.AddLeftChild(8)
	root.Left.AddRightChild(4)
	root.AddRightChild(3)
	res := lowestCommonAncestor(root, root.Left.Left.Left, root.Left.Right)
	fmt.Println(res)
}

func intp(x int) *int {
	return &x
}

var total = intp(0)

func lowestCommonAncestor(root, p, q *TreeNode) *TreeNode {
	if root == nil {
		return nil
	}

	if root.Val == p.Val || root.Val == q.Val {
		return root
	}

	var leftResult = lowestCommonAncestor(root.Left, p, q)
	var rightResult = lowestCommonAncestor(root.Right, p, q)

	if leftResult != nil && rightResult != nil {
		return root
	}

	if leftResult == nil {
		return rightResult
	}

	return leftResult
}
