package main

import "dsa"

type TreeNode = dsa.TreeNode

//https://leetcode.com/problems/delete-leaves-with-a-given-value/
func main() {
	var root = &TreeNode{Val: 1}
	root.AddLeftChild(2)
	root.Left.AddLeftChild(2)
	root.AddRightChild(3)
	root.Right.AddLeftChild(2)
	root.Right.AddRightChild(4)
	removeLeafNodes(root, 2)
}

func removeLeafNodes(root *TreeNode, target int) *TreeNode {
	return root
}
