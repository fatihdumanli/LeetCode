package main

//https://leetcode.com/problems/leaf-similar-trees/
func main() {
}

func leafSimilar(root1 *TreeNode, root2 *TreeNode) bool {

	var leafs1 []int
	var leafs2 []int

	inorder(root1, &leafs1)
	inorder(root2, &leafs2)

	if len(leafs1) != len(leafs2) {
		return false
	}


	for i := 0; i < len(leafs1); i++ {
		if leafs1[i] != leafs2[i] {
			return false
		}
	}

	return true
}


func inorder(root *TreeNode, arr *[]int) {
	if root == nil {
		return
	}

	inorder(root.Left, arr)
	if root.Left == nil && root.Right == nil {
		*arr = append(*arr, root.Val)
	}
	inorder(root.Right, arr)
}


type TreeNode struct {
	Left *TreeNode
	Val int
	Right *TreeNode
}
