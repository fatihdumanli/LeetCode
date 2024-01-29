package main

import "fmt"

type ListNode struct {
    Val int
    Next *ListNode
}

// https://leetcode.com/problems/implement-queue-using-stacks
type Stack struct {
    Head *ListNode
    Size int
}

func (s *Stack) pop() int {
    if s.isEmpty() {
        return -100
    }

    var val = s.Head.Val
    s.Head = s.Head.Next
    s.Size--
    return val
}

func (s *Stack) push(val int) {
    if s.Head == nil {
        s.Head = &ListNode{Val: val}
        s.Size++
        return
    }

    var newNode = &ListNode{Val: val}
    newNode.Next = s.Head
    s.Head = newNode
    s.Size++
}

func (s *Stack) peek() int {
    if s.isEmpty() {
        return -100
    }
    return s.Head.Val
}

func (s *Stack) isEmpty() bool {
    if s.Head == nil {
        return true
    }
    return false
}

type MyQueue struct {
    size int
    stack1 *Stack
    stack2 *Stack
}


func Constructor() MyQueue {
    return MyQueue{stack1: &Stack{}, stack2: &Stack{}}
}


func (this *MyQueue) Push(x int)  {
    if this.size == 0 {
        this.stack1.push(x)
        this.size++
        return
    }

    if this.stack1.Size == 0 {
        // We should only push to stack 1
        // If size is not 0, and and stack1 is empty, that means
        // The elements are currently in the stack 2 for reading
        var sz = this.stack2.Size

        for i := 0; i < sz; i++ {
            var elm = this.stack2.pop()
            this.stack1.push(elm)
        }
    }

    this.stack1.push(x)
    this.size++
}


func (this *MyQueue) Pop() int {
    if this.size == 0 {
        return -100
    }

    // move all elements to stack2 for reading
    var sz = this.stack1.Size

    for i := 0; i < sz; i++ {
        var elm = this.stack1.pop()
        this.stack2.push(elm)
    }

    var elm = this.stack2.pop()
    this.size--
    return elm
}


func (this *MyQueue) Peek() int {
    if this.size == 0 {
        return -100
    }
    
    // move all elements to stack2 for reading
    var sz = this.stack1.Size

    for i := 0; i < sz; i++ {
        var elm = this.stack1.pop()
        this.stack2.push(elm)
    }

    var elm = this.stack2.Head.Val
    return elm
}


func (this *MyQueue) Empty() bool {
    return this.size == 0
}


func main() {
    q := Constructor() 
    q.Push(1)
    q.Push(2)
    q.Push(3)
    q.Push(4)

    fmt.Println(q.Pop())
    q.Push(5)
    fmt.Println(q.Pop())
    fmt.Println(q.Pop())
    fmt.Println(q.Pop())
    fmt.Println(q.Pop())
}
