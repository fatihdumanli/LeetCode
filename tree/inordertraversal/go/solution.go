package main

import "fmt"

func main() {
    root := &TreeNode{Val: 1, Right: &TreeNode{Val: 2, Left: &TreeNode{Val: 3}}}
    r := inorderTraversal(root)
    fmt.Println(r)
}

func inorderTraversal(root *TreeNode) []int {
    var result []int

    var stack = Stack{}

    var ptr = root

    stack.Push(root)

    for stack.Length > 0 {

        if ptr == nil {
            var prevNode = stack.Pop()
            result = append(result, prevNode.Val)
            ptr = prevNode.Right
            continue
        }

        stack.Push(ptr)
        ptr = ptr.Left
        continue
    }

    return result[:len(result) - 1]
}


type TreeNode struct {
    Val int
    Left *TreeNode
    Right *TreeNode
}

type MyListNode struct {
    Val *TreeNode
    Next *MyListNode
}

type Stack struct {
    Length int
    head *MyListNode
}

func (s *Stack) Push(element *TreeNode) {
    s.Length++
    if s.head == nil {
        s.head = &MyListNode{Val: element}
        return
    }

    var temp = s.head
    s.head = &MyListNode{Val: element}
    s.head.Next = temp
}

func (s *Stack) Pop() *TreeNode {
    if s.Length == 0 {
        return nil
    }

    s.Length--

    var val = s.head
    s.head = s.head.Next
    return val.Val
}

