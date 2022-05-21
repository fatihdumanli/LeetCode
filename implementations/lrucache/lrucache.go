package main

type CacheNode struct {
	key  int
	val  int
	next *CacheNode
	prev *CacheNode
}

type LRUCache struct {
	cap  int
	len  int
	keys map[int]*CacheNode
	head *CacheNode
	tail *CacheNode
}

func Constructor(cap int) LRUCache {
	return LRUCache{
		cap:  cap,
		len:  0,
		keys: make(map[int]*CacheNode),
	}
}

func (this *LRUCache) Get(key int) int {
	node, ok := this.keys[key]
	if !ok {
		return -1
	}

	var nodeVal = node.val

	// If the node is already tail, do not anything
	if this.tail == node {
		return nodeVal
	}

	// Put recently accessed element to the tail
	if node.prev != nil {
		node.prev.next = node.next
	} else {
		//it's head.
		this.head = this.head.next
	}
	node.prev = this.tail
	this.tail.next = node
	this.tail = node

	return nodeVal
}

func (this *LRUCache) Put(key int, value int) {
	newNode := CacheNode{
		key: key,
		val: value,
	}

	_, ok := this.keys[key]


	if this.len < this.cap && !ok {
		this.len++
	} else if !ok  {
		// Eviction the LRU item (if it's not an update)
		var key = this.head.key
		delete(this.keys, key)

		this.head = this.head.next
	}

	if this.head == nil {
		this.head = &newNode
	}

	this.head.prev = nil

	// Put recently accessed item to the tail
	if this.tail == nil {
		this.tail = &newNode
	} else {
		this.tail.next = &newNode
		newNode.prev = this.tail
		this.tail = &newNode
	}

	this.keys[key] = &newNode
}
