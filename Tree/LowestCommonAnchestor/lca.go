package main

import "fmt"

type TreeNode struct {
	Val   int
	Left  *TreeNode
	Right *TreeNode
}

func main() {
	root := TreeNode{
		Val: 6,
		Left: &TreeNode{
			Val: 2,
			Left: &TreeNode{
				Val: 0,
			},
			Right: &TreeNode{
				Val: 4,
				Left: &TreeNode{
					Val: 3,
				},
				Right: &TreeNode{
					Val: 5,
				},
			},
		},
		Right: &TreeNode{
			Val: 8,
			Left: &TreeNode{
				Val: 7,
			},
			Right: &TreeNode{
				Val: 9,
			},
		},
	}

	/*
	         6
	      /     \
	     2       8
	    / \     / \
	   0   4   7   9
	      / \
	     3   5
	*/
	//2 and 8
	res := lowestCommonAncestor(&root, root.Left, root.Right)
	fmt.Println(res.Val)
}

func lowestCommonAncestor(root, p, q *TreeNode) *TreeNode {
	if root == nil {
		return root
	}

	if root.Val == q.Val || root.Val == p.Val {
		return root
	}

	leftResult := lowestCommonAncestor(root.Left, p, q)
	rightResult := lowestCommonAncestor(root.Right, p, q)

	if leftResult != nil && rightResult != nil {
		return root
	}

	if leftResult == nil {
		return rightResult
	}

	return leftResult
}
