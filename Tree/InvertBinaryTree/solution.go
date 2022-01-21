package main

import "fmt"

type TreeNode struct {
	Val   int
	Left  *TreeNode
	Right *TreeNode
}

func main() {
	root := TreeNode{Val: 2}
	root.Left = &TreeNode{Val: 1}
	root.Right = &TreeNode{Val: 3}
	invertTree(&root)
	fmt.Println("done")
}

func invertTree(root *TreeNode) *TreeNode {
	if root == nil {
		return nil
	}

	temp := root.Left
	root.Left = root.Right
	root.Right = temp

	invertTree(root.Left)
	invertTree(root.Right)

	return root
}
