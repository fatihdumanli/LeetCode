package main

import (
	"dsa"
	"fmt"
)

/*
write a program to sort a stack such that the smallest item are on the top.
you can use additional temporary stack, but you may not copy the elements into any other data strucure (such as an array).
the stack supports the following operations: push, pop, peek, and isEmpty
*/
func main() {

	s := dsa.NewStack()
	s.Push(1)
	s.Push(2)
	s.Push(9)
	s.Push(3)
	s.Push(4)

	sorted := sortStack(s)

	for !sorted.IsEmpty() {
		fmt.Println(sorted.Pop())
	}

}

func sortStack(s *dsa.Stack) *dsa.Stack {
	tmp := dsa.NewStack()

	for !s.IsEmpty() {
		popped, _ := s.Pop()

		for !tmp.IsEmpty() && peek(tmp) > popped {
			s.Push(pop(tmp))
		}

		tmp.Push(popped)
	}

	for !tmp.IsEmpty() {
		s.Push(pop(tmp))
	}

	return s
}

func pop(s *dsa.Stack) int {
	val, _ := s.Pop()
	return val
}
func peek(s *dsa.Stack) int {
	val, _ := s.Peek()
	return val
}
func Min(a, b int) int {
	if a < b {
		return a
	} else {
		return b
	}
}
