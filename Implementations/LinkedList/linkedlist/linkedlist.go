package linkedlist

type listNode struct {
	val  int
	next *listNode
}

//TODO: we could store a tail ptr to
//to make it faster to run AddAtTail() method.
type MyLinkedList struct {
	head *listNode
	size int
}

func Constructor() MyLinkedList {
	return MyLinkedList{}
}

func (this *MyLinkedList) Get(index int) int {
	if index < 0 || index >= this.size {
		return -1
	}

	ptr := this.head
	for i := 0; i < index; i++ {
		ptr = ptr.next
	}

	return ptr.val
}

func (this *MyLinkedList) AddAtHead(val int) {
	this.size++

	if this.head == nil {
		this.head = &listNode{val: val}
		return
	}

	newHead := &listNode{val: val, next: this.head}
	this.head = newHead
}

func (this *MyLinkedList) AddAtTail(val int) {
	this.size++
	if this.head == nil {
		this.head = &listNode{val: val}
		return
	}

	ptr := this.head

	for ptr.next != nil {
		ptr = ptr.next
	}

	ptr.next = &listNode{val: val}
}

func (this *MyLinkedList) AddAtIndex(index int, val int) {
	if index < 0 || index > this.size+1 {
		return
	}

	this.size++
	if this.head == nil {
		this.head = &listNode{val: val}
		return
	}

	ptr := this.head
	for i := 0; i < index-1; i++ {
		ptr = ptr.next
	}

	ptr.next = &listNode{val: val}
}

func (this *MyLinkedList) DeleteAtIndex(index int) {
	if index < 0 || index >= this.size {
		return
	}
	this.size--

	if index == 0 {
		this.head = this.head.next
		return
	}

	ptr := this.head
	for i := 0; i < index-1; i++ {
		ptr = ptr.next
	}

	ptr.next = ptr.next.next
}
