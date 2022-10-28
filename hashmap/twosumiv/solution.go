package main

import "fmt"

type TreeNode struct {
	Val   int
	Left  *TreeNode
	Right *TreeNode
}

func main() {
	root := &TreeNode{Val: 5, Left: &TreeNode{Val: 3, Left: &TreeNode{Val: 2}, Right: &TreeNode{Val: 4}}, Right: &TreeNode{Val: 6, Right: &TreeNode{Val: 7}}}
	k := 9
	r := findTarget(root, k)
	fmt.Println(r)
}

func findTarget(root *TreeNode, k int) bool {
	var hashset = make(map[int]bool)
	return inOrderTraversal(root, k, hashset)
}

func inOrderTraversal(root *TreeNode, k int, hashset map[int]bool) bool {
	if root == nil {
		return false
	}
	l := inOrderTraversal(root.Left, k, hashset)
	if l {
		return true
	}
	var key = k - root.Val
	if hashset[key] {
		return true
	}

	hashset[root.Val] = true
	r := inOrderTraversal(root.Right, k, hashset)
	return r
}
