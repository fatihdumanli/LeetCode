package hashset

type listNode struct {
	val  int
	next *listNode
}

type MyHashSet struct {
	buckets []*listNode
}

func Constructor() MyHashSet {
	bckts := make([]*listNode, 100)
	return MyHashSet{buckets: bckts}
}

func (this *MyHashSet) Add(key int) {
	var bucketIndex = key % len(this.buckets)
	var bucket = this.buckets[bucketIndex]

	if bucket == nil {
		bucket = &listNode{val: key}
		this.buckets[bucketIndex] = bucket
		return
	}

	if bucket.val == key {
		return
	}

	for bucket.next != nil {
		//already contains
		if bucket.val == key {
			return
		}
		bucket = bucket.next
	}
	bucket.next = &listNode{val: key}
}

func (this *MyHashSet) Remove(key int) {
	var bucketIndex = key % len(this.buckets)
	var bucket = this.buckets[bucketIndex]

	//means there's no such value
	if bucket == nil {
		return
	}

	//if it's head
	if bucket.val == key {
		bucket = bucket.next
		this.buckets[bucketIndex] = bucket
		return
	}

	for bucket.next != nil {
		if bucket.next.val == key {
			bucket.next = bucket.next.next
			return
		}

		bucket = bucket.next
	}

}

func (this *MyHashSet) Contains(key int) bool {
	var bucketIndex = key % len(this.buckets)
	var bucket = this.buckets[bucketIndex]

	if bucket == nil {
		return false
	}

	for bucket != nil {
		if bucket.val == key {
			return true
		}
	return false
}
