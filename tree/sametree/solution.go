package main

import "fmt"

type TreeNode struct {
	Val   int
	Left  *TreeNode
	Right *TreeNode
}

func main() {
	p := TreeNode{Val: 1}
	p.Left = &TreeNode{Val: 2}
	q := TreeNode{Val: 1}
	q.Left = &TreeNode{Val: 2}

	fmt.Println(isSameTree(&p, &q))
}

func isSameTree(p *TreeNode, q *TreeNode) bool {
	if p == nil && q == nil {
		return true
	}

	if p == nil || q == nil {
		return false
	}

	if p.Val != q.Val {
		return false
	}

	return isSameTree(p.Left, q.Left) && isSameTree(p.Right, q.Right)
}
