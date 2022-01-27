package main

import (
	"errors"
	"math"
)

type stackNode struct {
	val     int
	next    *stackNode
	nextMin *stackNode
}

type Minstack struct {
	min *stackNode
	top *stackNode
}

func (s *Minstack) Push(val int) error {

	newTop := stackNode{val: val, next: s.top}
	if val < s.min.val {
		newTop.nextMin = s.min
		s.min = &newTop
	}
	s.top = &newTop
	return nil
}

func (s *Minstack) Pop() (int, error) {

	if s.top == nil {
		return -1, errors.New("Stack is empty!")
	}

	top := s.top

	if s.min == top {
		s.min = top.nextMin
	}

	s.top = s.top.next
	return top.val, nil
}

func (s *Minstack) Min() (int, error) {
	if s.min != nil {
		return s.min.val, nil
	}
	return 0, nil
}

func (s *Minstack) IsEmpty() bool {
	return s.top == nil
}

func NewStack() *Minstack {
	return &Minstack{
		min: &stackNode{
			val: math.MaxInt32,
		},
	}
}
