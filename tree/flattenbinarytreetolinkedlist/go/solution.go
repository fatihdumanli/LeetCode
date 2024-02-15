package main

type TreeNode struct {
    Val int
    Left *TreeNode
    Right *TreeNode
}

func main() {
    root := &TreeNode{Val: 1}
    root.Left = &TreeNode{Val: 2}
    root.Left.Left = &TreeNode{Val: 3}
    root.Left.Right = &TreeNode{Val: 4}
    root.Right = &TreeNode{Val: 5}
    root.Right.Right = &TreeNode{Val: 6}
    
    flatten(root)
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

func flatten(root *TreeNode) {
    if root == nil {
        return
    }

    var nodes []int
    var stack = Stack{}

    stack.Push(root)

    var ptr = root
    for stack.Length > 0 {

        if ptr == nil {
            var prevRoot = stack.Pop()
            ptr = prevRoot.Right
            continue
        }

        nodes = append(nodes, ptr.Val)
        stack.Push(ptr)
        ptr = ptr.Left
        continue
    }

    root.Left = nil
    ptr = root

    for i := 0; i < len(nodes) - 1; i++ {
        ptr.Val = nodes[i]

        ptr.Left = nil
        if ptr.Right == nil {
            ptr.Right = &TreeNode{}
        }
        ptr = ptr.Right
    }

    ptr.Val = nodes[len(nodes) - 1]
}



















