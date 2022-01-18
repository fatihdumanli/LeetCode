package main

import (
	"fmt"
	"log"
)

func main() {
	s := "()"
	res := isValid(s)
	fmt.Println(res)
}

func isValid(s string) bool {

	if len(s) <= 1 {
		return false
	}

	var brackets = make(map[rune]rune, 3)
	brackets['('] = ')'
	brackets['{'] = '}'
	brackets['['] = ']'

	stack := make([]interface{}, 0)
	for _, c := range s {
		if brackets[c] != 0 {
			push(&stack, brackets[c])
			continue
		}

		if len(stack) == 0 {
			return false
		}

		expected := pop(&stack)
		if c != expected {
			return false
		}
	}

	return len(stack) == 0
}

func push(stack *[]interface{}, value interface{}) {
	*stack = append(*stack, value)
}

func pop(stack *[]interface{}) interface{} {
	size := len(*stack)

	if size == 0 {
		log.Fatal("stack is empty")
		return nil
	}

	val := (*stack)[size-1]
	*stack = (*stack)[:size-1]
	return val
}
