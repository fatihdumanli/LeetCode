package main

import "fmt"

func main() {

	var minStack = NewStack()

	minStack.Push(40)
	minStack.Push(60)
	minStack.Push(30)
	minStack.Push(20)
	minStack.Push(10)
	minStack.Push(90)

	for !minStack.IsEmpty() {
		popped, _ := minStack.Pop()
		fmt.Println("popped ", popped)
		min, _ := minStack.Min()
		fmt.Println("min", min)
	}

}
