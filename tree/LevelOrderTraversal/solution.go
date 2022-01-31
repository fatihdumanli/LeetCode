package main

import "fmt"

type TreeNode struct {
	Val   int
	Left  *TreeNode
	Right *TreeNode
}

func main() {
	root := TreeNode{Val: 3}
	root.Left = &TreeNode{Val: 9}
	root.Right = &TreeNode{Val: 20}
	root.Right.Left = &TreeNode{Val: 15}
	root.Right.Right = &TreeNode{Val: 7}

	result := levelOrder(&root)
	fmt.Println(result)
}

func levelOrder(root *TreeNode) [][]int {
	var result [][]int

	if root == nil {
		return result
	}

	var queue []*TreeNode
	queue = make([]*TreeNode, 0)

	enqueue(&queue, root)
	result = append(result, []int{root.Val})

	for !isQueueEmpty(&queue) {
		var list []*TreeNode

		for !isQueueEmpty(&queue) {
			dequeued := dequeue(&queue)
			if dequeued.Left != nil {
				list = append(list, dequeued.Left)
			}

			if dequeued.Right != nil {
				list = append(list, dequeued.Right)
			}
		}

		var valList []int
		for _, elm := range list {
			valList = append(valList, elm.Val)
			enqueue(&queue, elm)
		}

		if len(valList) > 0 {
			result = append(result, valList)
		}
	}
	return result
}

func isQueueEmpty(q *[]*TreeNode) bool {
	return len(*q) == 0
}

func enqueue(q *[]*TreeNode, node *TreeNode) {
	*q = append(*q, node)
}

func dequeue(q *[]*TreeNode) *TreeNode {
	top := (*q)[0]
	*q = (*q)[1:]
	return top
}
