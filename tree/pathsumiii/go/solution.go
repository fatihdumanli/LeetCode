package main

import (
	"dsa"
	"fmt"
)

type TreeNode = dsa.TreeNode

var tottt = 0

func main() {
	var root = &TreeNode{Val: 10}
	root.AddLeftChild(5)
	root.AddRightChild(-3)
	root.Left.AddLeftChild(3)
	root.Left.AddRightChild(2)
	root.Left.Right.AddRightChild(1)
	root.Left.Left.AddLeftChild(3)
	root.Left.Left.AddRightChild(-2)

	root.Right.AddRightChild(11)
	fmt.Println(pathSum(root, 8))

}

func pathSum(root *TreeNode, targetSum int) int {
	if root == nil {
		return 0
	}

	r := iterateOverChildren(root, 0, targetSum)

	l := pathSum(root.Left, targetSum)
	right := pathSum(root.Right, targetSum)

	return r + l + right
}

func iterateOverChildren(root *TreeNode, sum int, target int) int {
	if root == nil {
		return 0
	}

	var total = 0
	sum += root.Val

	if sum == target {
		total++
	}

	left := iterateOverChildren(root.Left, sum, target)
	right := iterateOverChildren(root.Right, sum, target)
	total += left + right

	return total
}
