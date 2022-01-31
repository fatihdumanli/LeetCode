package main

import "fmt"

type AnimalType string

const (
	tcat AnimalType = "cat"
	tdog AnimalType = "dog"
)

type animal struct {
	index  int
	family AnimalType
	name   string
	age    int
}

type animalNode struct {
	val  animal
	next *animalNode
}

func main() {
	shelter := AnimalShelter{}
	enqueue(&shelter, animal{
		name:   "tefo",
		age:    3,
		family: "cat",
	})
	enqueue(&shelter, animal{
		name:   "hera",
		age:    2,
		family: "dog",
	})
	enqueue(&shelter, animal{
		name:   "kiraz",
		age:    4,
		family: "cat",
	})
	fmt.Println(dequeueAny(&shelter))
	fmt.Println(dequeueAny(&shelter))
	fmt.Println(dequeueAny(&shelter))
	fmt.Println(dequeueAny(&shelter))
	fmt.Println(dequeueAny(&shelter))
	fmt.Println(dequeueAny(&shelter))
	fmt.Println(dequeueAny(&shelter))
	fmt.Println(dequeueAny(&shelter))
}

type AnimalShelter struct {
	seq      int
	catsHead *animalNode
	dogsHead *animalNode
}

func enqueue(as *AnimalShelter, a animal) {

	if a.family != tcat && a.family != tdog {
		panic("You can only enqueue either cat or dog")
	}

	as.seq++
	a.index = as.seq
	isCat := a.family == tcat

	var ptr *animalNode

	if isCat {
		if as.catsHead == nil {
			as.catsHead = &animalNode{val: a}
			return
		}
		ptr = as.catsHead
	} else {
		if as.dogsHead == nil {
			as.dogsHead = &animalNode{val: a}
			return
		}
		ptr = as.dogsHead
	}

	for ptr.next != nil {
		ptr = ptr.next
	}

	ptr.next = &animalNode{val: a}
}

func dequeueDog(as *AnimalShelter) animal {
	if as.dogsHead == nil {
		panic("there's no dog!")
	}

	first := as.dogsHead.val
	as.dogsHead = as.dogsHead.next
	return first
}

func dequeueCat(as *AnimalShelter) animal {
	if as.catsHead == nil {
		panic("there's no cat!")
	}
	first := as.catsHead.val
	as.catsHead = as.catsHead.next
	return first
}

func dequeueAny(as *AnimalShelter) animal {
	if as.catsHead == nil && as.dogsHead == nil {
		panic("there's no animal")
	}

	if as.catsHead == nil {
		return dequeueDog(as)
	}

	if as.dogsHead == nil {
		return dequeueCat(as)
	}

	if as.catsHead.val.index < as.dogsHead.val.index {
		return dequeueCat(as)
	} else {
		return dequeueDog(as)
	}
}
