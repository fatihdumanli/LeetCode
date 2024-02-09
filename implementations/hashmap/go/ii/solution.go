package main

import "fmt"

func main() {
    instance := Constructor()

    instance.Put(2, 2)
    instance.Put(2, 1)

    val := instance.Get(2)
    fmt.Println(val)
}

type Node struct {
    Key int
    Val int
    Next *Node
}

type MyHashMap struct {
    bucketCount int
    buckets []*Node
}


func Constructor() MyHashMap {
    var bucketCount = 10
    var buckets = make([]*Node, bucketCount)

    return MyHashMap{buckets: buckets, bucketCount: bucketCount}
}


func (this *MyHashMap) Put(key int, value int)  {
    var index = key % this.bucketCount
    
    var head = this.buckets[index]

    if head == nil {
        this.buckets[index] = &Node{Key: key, Val: value}
        return
    }

    if head.Key == key {
        head.Val = value
        return
    }

    var ptr = head

    for ptr.Next != nil {

        // Update
        if ptr.Key == key {
            ptr.Val = value
            return
        }

        ptr = ptr.Next
    }

    if ptr.Key == key {
        ptr.Val = value
        return
    }

    // Append
    ptr.Next = &Node{Key: key, Val: value}
}


func (this *MyHashMap) Get(key int) int {
    var index = key % 10

    var head = this.buckets[index]

    if head == nil {
        return -1
    }

    var ptr = head
    for ptr != nil {
        if ptr.Key == key {
            return ptr.Val
        }
        ptr = ptr.Next
    }

    return -1
}


func (this *MyHashMap) Remove(key int)  {
    var index = key % 10

    var head = this.buckets[index]

    if head == nil {
        return
    }

    if head.Key == key {
        this.buckets[index] = this.buckets[index].Next
        return
    }

    var ptr = head

    for ptr.Next != nil {
        if ptr.Next.Key == key {
            ptr.Next = ptr.Next.Next
            return
        }
        ptr = ptr.Next
    }
}

