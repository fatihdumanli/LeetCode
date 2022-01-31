package main

import (
	"dsa"
	"errors"
	"fmt"
)

type MyQueue struct {
	one *dsa.Stack
	two *dsa.Stack
}

func NewQueue() MyQueue {
	one := dsa.NewStack()
	two := dsa.NewStack()

	return MyQueue{
		one: one,
		two: two,
	}
}

func enqueue(q MyQueue, val int) {

	if q.two.Length > 0 {
		for !q.two.IsEmpty() {
			popped, _ := q.two.Pop()
			q.one.Push(popped)
		}
	}

	q.one.Push(val)
}

func dequeue(q MyQueue) (int, error) {

	//that means the last operation was dequeue
	if q.two.Length > 0 {
		top, err := q.two.Pop()
		if err != nil {
			return -1, err
		}
		return top, nil
	}

	for !q.one.IsEmpty() {
		popped, _ := q.one.Pop()
		q.two.Push(popped)
	}
	top, err := q.two.Pop()

	if err != nil {
		if errors.Is(err, dsa.StackIsEmpty) {
			return -1, errors.New("Queue is empty!")
		}
	}

	return top, err
}

func main() {
	q := NewQueue()

	enqueue(q, 1)
	enqueue(q, 10)
	enqueue(q, 20)
	enqueue(q, 30)
	enqueue(q, 40)
	enqueue(q, 50)
	enqueue(q, 60)

	fmt.Println(dequeue(q))
	fmt.Println(dequeue(q))
	fmt.Println(dequeue(q))
	fmt.Println(dequeue(q))
	fmt.Println(dequeue(q))
	fmt.Println(dequeue(q))
	fmt.Println(dequeue(q))
	fmt.Println(dequeue(q))
	fmt.Println(dequeue(q))

}
