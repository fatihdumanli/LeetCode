package main

import "fmt"

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

func main() {
    root := &TreeNode{Val: 1, Right: &TreeNode{Val: 2, Left: &TreeNode{Val: 3}}}
    r := preorderTraversal(root)
    fmt.Println(r)
}

func preorderTraversal(root *TreeNode) []int {

    var ptr = root

    if ptr == nil {
        return []int{}
    }

    var result []int

    var stack = Stack{}
    stack.Push(root)

    for stack.Length > 0 {
        if ptr == nil {
            var prevRoot = stack.Pop()
            ptr = prevRoot.Right
            continue
        }

        result = append(result, ptr.Val)
        stack.Push(ptr)
        ptr = ptr.Left
    }


    return result
}
