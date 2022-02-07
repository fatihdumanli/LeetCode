package main

import "fmt"

type TreeNode struct {
	Val    int
	Left   *TreeNode
	Right  *TreeNode
	Parent *TreeNode
}

func (root *TreeNode) AddLeftChild(val int) {
	root.Left = &TreeNode{Val: val}
}

func (root *TreeNode) AddRightChild(val int) {
	root.Right = &TreeNode{Val: val}
}
func main() {

	var root = &TreeNode{Val: 20}
	root.AddLeftChild(8)
	root.Left.Parent = root
	root.AddRightChild(27)
	root.Right.Parent = root
	root.Left.AddLeftChild(4)
	root.Left.Left.Parent = root.Left
	root.Left.AddRightChild(12)
	root.Left.Right.Parent = root.Left
	root.Left.Right.AddLeftChild(10)
	root.Left.Right.Left.Parent = root.Left.Right
	root.Left.Right.AddRightChild(14)
	root.Left.Right.Right.Parent = root.Left.Right
	root.Right.AddLeftChild(22)
	root.Right.Left.Parent = root.Right
	root.Right.AddRightChild(30)
	root.Right.Right.Parent = root.Right

	var res = findSuccessor(root.Right.Right)
	fmt.Println(res)

}

func findSuccessor(node *TreeNode) *TreeNode {
	if node == nil {
		return nil
	}

	//Edge case
	if node.Parent == nil {
		var left *TreeNode
		left = node.Left

		for left != nil {
			left = left.Left
		}

		return left
	}

	if node.Right != nil {
		return node.Right
	}

	var parent *TreeNode
	parent = node.Parent

	//That means "node" is the left child.
	if parent.Val > node.Val {
		return node.Parent
	}

	for parent.Val <= node.Val {
		parent = parent.Parent
		if parent == nil {
			return parent
		}
	}

	return parent
}
