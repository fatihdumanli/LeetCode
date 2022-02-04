package main

import (
	"dsa"
	"fmt"
)

type TreeNode = dsa.TreeNode

type ListNode struct {
	Val  *TreeNode
	Next *ListNode
}

func main() {
	var root = &TreeNode{Val: 10}
	root.AddLeftChild(5)
	root.AddRightChild(15)
	root.Left.AddLeftChild(3)
	root.Left.AddRightChild(7)
	root.Right.AddLeftChild(11)
	root.Right.AddRightChild(17)

	lod := listOfDepths(root)

	for _, e := range lod {
		var ptr = e
		for ptr != nil {
			curVal := ptr.Val.Val
			fmt.Printf("%d ", curVal)
			ptr = ptr.Next
		}
		fmt.Println(" ")
	}
}

func listOfDepths(root *TreeNode) []*ListNode {

	var result []*ListNode
	var queue = dsa.NewQueue()

	queue.Enqueue(root)

	result = append(result, &ListNode{Val: root})

	var listNode = &ListNode{}
	var ptr = listNode

	for !queue.IsEmpty() {
		var dequeued, _ = queue.Dequeue()
		var node = dequeued.(*TreeNode)

		if node.Left != nil {
			ptr.Next = &ListNode{Val: node.Left}
			ptr = ptr.Next
		}
		if node.Right != nil {
			ptr.Next = &ListNode{Val: node.Right}
			ptr = ptr.Next
		}

		if queue.IsEmpty() {
			listNode = listNode.Next
			result = append(result, listNode)
			for listNode != nil {
				queue.Enqueue(listNode.Val)
				listNode = listNode.Next
			}
			listNode = &ListNode{}
			ptr = listNode
		}
	}
	return result
}
