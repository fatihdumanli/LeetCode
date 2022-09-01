package stack

import "errors"

type stackNode struct {
	val  int
	next *stackNode
}

type Stack struct {
	top *stackNode
}

func NewStack() *Stack {
	return &Stack{}
}

func (s *Stack) Push(val int) {
	s.top = &stackNode{val: val, next: s.top}
}

func (s *Stack) Pop() (int, error) {
	topVal := s.top.val
	s.top = s.top.next
	return topVal, nil
}

func (s *Stack) Peek() (int, error) {
	if s.top == nil {
		return -1, errors.New("Stack is empty!")
	}
	return s.top.val, nil
}

func (s *Stack) IsEmpty() bool {
	return s.top == nil
}
