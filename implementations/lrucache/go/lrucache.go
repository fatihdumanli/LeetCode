package main

import "math"

type CacheNode struct {
	key   int
	value int
	next  *CacheNode
}

type LRUCache struct {
	capacity int
	head     *CacheNode
	tail     *CacheNode
	keys     map[int]*CacheNode
	length   int
}

func Constructor(capacity int) LRUCache {

	head := &CacheNode{
		key:   math.MinInt32,
		value: math.MinInt32,
	}

	return LRUCache{
		capacity: capacity,
		keys:     make(map[int]*CacheNode),
		head:     head,
		tail:     head,
	}
}

func (this *LRUCache) Get(key int) int {
	var node, ok = this.keys[key]

	if !ok {
		return -1
	}

	// it's already on the tail
	if key == this.tail.key {
		return node.next.value
	}

	var nodeVal = node.next.value
	var tempNode = node.next

	// Put it to the tail
	var childKey = this.keys[key].next.next.key
	this.keys[childKey] = this.keys[key]
	this.keys[key].next = this.keys[key].next.next
	this.keys[key] = this.tail
	this.tail.next = tempNode
	this.tail = this.tail.next
	this.tail.next = nil

	return nodeVal
}

func (this *LRUCache) Put(key int, value int) {

	_, ok := this.keys[key]

	if ok {
		// key already exists, update
		// TODO: put it to the tail in case of update

		if this.tail.key == key {
			this.keys[key].next.value = value
			return
		}

		node := this.keys[key].next
		this.keys[key].next = this.keys[key].next.next
		node.value = value
		this.tail.next = node
		this.tail = this.tail.next
		return
	}

	if this.length >= this.capacity {

		var keyToEvict int
		// If we're about to evict the tail
		if this.tail == this.head.next {
			keyToEvict = this.tail.key
			this.tail = this.head
		} else {
			keyToEvict = this.head.next.key
			this.head.next = this.head.next.next
		}

		//Evict the head.
		delete(this.keys, keyToEvict)
	} else {
		this.length++
	}

	this.keys[key] = this.tail

	newNode := &CacheNode{
		key:   key,
		value: value,
	}

	this.tail.next = newNode
	this.tail = this.tail.next
}
