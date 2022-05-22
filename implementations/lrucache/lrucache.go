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

	if this.tail == node {
		return nodeVal
	}

	if node.prev != nil {
		node.prev.next = node.next
		node.next.prev = node.prev
	} else {
		this.head = this.head.next
	}

	node.next = nil
	this.tail.next = node
	node.prev = this.tail
	this.tail = node

	return nodeVal
}

func (this *LRUCache) Put(key int, value int) {
	newNode := CacheNode{
		key: key,
		val: value,
	}

	// This means the tail is also nil
	if this.head == nil {
		this.head = &newNode
		this.tail = &newNode
		this.len++
		this.keys[key] = &newNode
		return
	}

	existingNode, ok := this.keys[key]
	if ok {
		// Put it to the tail
		replaceTail(this, existingNode)

		if this.head == existingNode {
			this.head = this.head.next
		}

		this.keys[key] = &newNode
		return
	}

	if this.len >= this.cap {
		//Evict
		var head = this.head
		delete(this.keys, head.key)

		this.head = this.head.next

		if this.head == nil {
			this.head = &newNode
		}

		this.head.prev = nil

	} else {
		this.len++
	}

	this.keys[key] = &newNode
	replaceTail(this, &newNode)

}

func replaceTail(cache *LRUCache, newNode *CacheNode) {
	// Put recently accessed item to the tail
	if cache.tail == nil {
		cache.tail = newNode
	} else {
		cache.tail.next = newNode
		newNode.prev = cache.tail
		cache.tail = newNode
	}
}
