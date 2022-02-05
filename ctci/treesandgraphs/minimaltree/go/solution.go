package main

import (
	"dsa"
	"os"
)

type TreeNode = dsa.TreeNode

func main() {
	var arr = []int{1, 4, 7, 9, 11, 15}
	var tree = createMinimalTree(arr)
	tree.Print(os.Stdout)

}

func createMinimalTree(arr []int) *TreeNode {
	if len(arr) < 1 {
		return nil
	}
	var mid = (0 + len(arr)) / 2
	node := &TreeNode{Val: arr[mid]}
	//Create the left subtree with the left half of the array
	node.Left = createMinimalTree(arr[:mid])
	//Do so for the right subtree
	node.Right = createMinimalTree(arr[mid+1:])
	return node
}
