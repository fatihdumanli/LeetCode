package main

import (
	"errors"
	"fmt"
)

const STACK_THRESHOLD = 3

type SetOfStacks struct {
	stacks      *[]*[]int
	numOfStacks *int
}

func intp(x int) *int {
	return &x
}

//*[]int{} => pointer of list of integers
func NewSetOfStacks() SetOfStacks {

	listOfStacks := []*[]int{}
	listOfStacks = append(listOfStacks, &[]int{})

	return SetOfStacks{
		numOfStacks: intp(1),
		stacks:      &listOfStacks,
	}
}

func push(sos SetOfStacks, val int) {

	if *sos.numOfStacks == 0 {
		*sos.stacks = append(*sos.stacks, &[]int{})
		*sos.numOfStacks = 1
	}
	//list of pointer of list of integers
	listOfStacks := *sos.stacks

	//listOfStacks[0] = pointer of list of integers
	//listOfStacks[1] = another pointer of list of integers

	//actual ptr to the current stack (current list of integers)
	curPtr := listOfStacks[*sos.numOfStacks-1]

	if len(*curPtr) >= STACK_THRESHOLD {
		//need to create a new stack here
		newStack := []int{}
		*sos.stacks = append(*sos.stacks, &newStack)
		*sos.numOfStacks++
		curPtr = (*sos.stacks)[*sos.numOfStacks-1]
	}

	*curPtr = append(*curPtr, val)
	vals := *curPtr
	_ = vals
}

func pop(s SetOfStacks) (int, error) {

	if *s.numOfStacks == 0 {
		return -1, errors.New("stack is empty!")
	}

	//list of pointers of list of integers
	listOfStacks := *s.stacks

	//pointer to the current list of integers
	curPtr := listOfStacks[*s.numOfStacks-1]
	top := (*curPtr)[len(*curPtr)-1]

	*curPtr = (*curPtr)[:len(*curPtr)-1]

	if len(*curPtr) == 0 {
		*s.numOfStacks--
		*s.stacks = (*s.stacks)[:len(*s.stacks)-1]
	}

	fmt.Println("popped element, cur numOfStc is", *s.numOfStacks)
	return top, nil
}

func main() {
	sos := NewSetOfStacks()

	push(sos, 3)
	push(sos, 4)
	push(sos, 5)
	push(sos, 6)

	fmt.Println(pop(sos))
	fmt.Println(pop(sos))
	fmt.Println(pop(sos))
	fmt.Println(pop(sos))
	fmt.Println(pop(sos))

	push(sos, 10)
	push(sos, 20)
	push(sos, 30)
	push(sos, 40)
	push(sos, 50)

	fmt.Println(pop(sos))
	fmt.Println(pop(sos))
	fmt.Println(pop(sos))
	fmt.Println(pop(sos))
	fmt.Println(pop(sos))
	fmt.Println(pop(sos))
	fmt.Println(pop(sos))
	fmt.Println(pop(sos))
	fmt.Println(pop(sos))
	fmt.Println(pop(sos))
}
