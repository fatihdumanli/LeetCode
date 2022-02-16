package main

import (
	"dsa"
)

type TreeNode = dsa.TreeNode

func main() {

	var preorder = []int{3, 9, 20, 15, 7}
	var inorder = []int{9, 3, 15, 20, 7}

	newTree := buildTree(preorder, inorder)

	l := newTree.Left
	r := newTree.Right
	_ = l
	_ = r
}

func buildTree(preorder []int, inorder []int) *TreeNode {

	if len(inorder) == 0 || len(preorder) == 0 {
		return nil
	}
	var root = &TreeNode{Val: preorder[0]}

	//the idx is also the num of elements in the left subtree
	var idx = indexOf(inorder, root.Val)
	var rightPreorder = preorder[idx+1:]
	var leftInOrder = inorder[:idx]
	var rightInorder = inorder[idx+1:]

	root.Left = buildTree(preorder[1:], leftInOrder)
	root.Right = buildTree(rightPreorder, rightInorder)
	return root
}

func indexOf(arr []int, val int) int {
	for i, v := range arr {
		if v == val {
			return i
		}
	}
	return -1
}
