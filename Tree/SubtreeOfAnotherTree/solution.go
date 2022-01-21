package main

import "fmt"

type TreeNode struct {
	Val   int
	Left  *TreeNode
	Right *TreeNode
}

func main() {
	root := TreeNode{Val: 3}
	root.Right = &TreeNode{Val: 5}
	root.Left = &TreeNode{Val: 4}
	root.Left.Left = &TreeNode{Val: 1}
	root.Left.Right = &TreeNode{Val: 2}

	subRoot := TreeNode{Val: 4}
	subRoot.Left = &TreeNode{Val: 1}
	subRoot.Right = &TreeNode{Val: 2}
	subRoot.Left.Left = &TreeNode{Val: 5}

	res := isSubTree(&root, &subRoot)
	fmt.Println(res)
}
func isSubTree(root *TreeNode, subRoot *TreeNode) bool {
	var possibleNodes []*TreeNode
	findPossibleNodes(&possibleNodes, root, subRoot.Val)

	for _, p := range possibleNodes {
		if isSame := isSameTree(p, subRoot); isSame {
			return true
		}
	}

	return false
}

func findPossibleNodes(arr *[]*TreeNode, root *TreeNode, val int) {
	if root == nil {
		return
	}

	findPossibleNodes(arr, root.Left, val)

	if root.Val == val {
		*arr = append(*arr, root)
	}

	findPossibleNodes(arr, root.Right, val)
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
