package main

import "fmt"

//TODO: get options to determine whether override an existing key.
type listNode struct {
	key   int
	value int
	next  *listNode
}

type MyHashMap struct {
	buckets []*listNode
}

func Constructor() MyHashMap {
	buckets := make([]*listNode, 100)
	return MyHashMap{buckets: buckets}
}

func (this *MyHashMap) Put(key int, value int) {
	var bucketIndex = key % len(this.buckets)
	bucket := this.buckets[bucketIndex]

	if bucket == nil {
		this.buckets[bucketIndex] = &listNode{key: key, value: value}
		return
	}

	if bucket.key == key {
		bucket.value = value
		return
	}

	//for bucket != nil && bucket.next != nil {
	//	if bucket.key == key {
	//		bucket.value = value
	//		return
	//	}
	//	bucket = bucket.next
	//}

	for bucket.next != nil {
		if bucket.next.key == key {
			bucket.next.value = value
		}

		bucket = bucket.next
	}

	bucket.next = &listNode{key: key, value: value}
}

func (this *MyHashMap) Get(key int) int {

	var bucketIndex = key % len(this.buckets)
	bucket := this.buckets[bucketIndex]

	for bucket != nil {
		if bucket.key == key {
			return bucket.value
		}
		bucket = bucket.next
	}

	return -1
}

func (this *MyHashMap) Remove(key int) {
	var bucketIndex = key % len(this.buckets)
	bucket := this.buckets[bucketIndex]

	if bucket == nil {
		return
	}

	if bucket.key == key {
		this.buckets[bucketIndex] = this.buckets[bucketIndex].next
		return
	}

	for bucket.next != nil {
		if bucket.next.key == key {
			bucket.next = bucket.next.next
			return
		}
		bucket = bucket.next
	}
}

func main() {
	var h = Constructor()
	for i := 0; i < 1_000_00; i++ {
		h.Put(i, i)
	}
	fmt.Println("done")

}
