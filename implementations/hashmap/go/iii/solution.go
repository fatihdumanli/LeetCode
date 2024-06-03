package main

import "hash/fnv"
import "strconv"

type MyListNode struct {
    Key int
    Value int
    Next *MyListNode
}

type MyHashMap struct {
    buckets []*MyListNode
}

func (this *MyHashMap) Put(key int, value int) {

    var hash = HashInt32(key)
    var bucketIdx = hash % uint32(len(this.buckets))

    var head = this.buckets[bucketIdx]

    // the corresponding bucket does not have any node - set the head
    if head == nil {
        this.buckets[bucketIdx] = &MyListNode{Key: key, Value: value}
        return
    }

    // we need to update the value if the key exists
    var ptr = head

    for ptr != nil {
        if ptr.Key == key {
            ptr.Value = value
            return
        }
        ptr = ptr.Next
    }

    // couldn't find the key - replace the head
    var newHead = &MyListNode{Key: key, Value: value}
    newHead.Next = this.buckets[bucketIdx]
    this.buckets[bucketIdx] = newHead
}

func (this *MyHashMap) Get(key int) int {
    var hash = HashInt32(key)

    var bucketIdx = hash % uint32(len(this.buckets))
    var bucket = this.buckets[bucketIdx]

    if bucket == nil {
        return -1
    }

    for bucket != nil {
        if bucket.Key == key {
            return bucket.Value
        }
        bucket = bucket.Next
    }

    // could not find the key
    return -1
}


func (this *MyHashMap) Remove(key int) {

    var hash = HashInt32(key)
    var bucketIdx = hash % uint32(len(this.buckets))
    var bucket = this.buckets[bucketIdx]

    // even bucket does not exist
    if bucket == nil {
        return; 
    }

    // head
    if bucket.Key == key {
        this.buckets[bucketIdx] = this.buckets[bucketIdx].Next
        return
    }

    var ptr = bucket
    for ptr.Next != nil {
        if ptr.Next.Key == key {
            ptr.Next = ptr.Next.Next
            return;
        }
        ptr = ptr.Next
    }
}


func Constructor() *MyHashMap {
    var bucketSize = 10
    return &MyHashMap{buckets: make([]*MyListNode, bucketSize, bucketSize)}
}

func HashInt32(key int) uint32 {
    hasher := fnv.New32a()
    hasher.Write([]byte(strconv.Itoa(key)))
    return hasher.Sum32()
}
