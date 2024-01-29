package main

import (
	"fmt"
	"math"
)

type ListNode struct {
    Val int
    Next *ListNode
}

func main() {
    lists := []*ListNode{}
    lists = append(lists, nil)
    lists = append(lists, nil)

    r := mergeKLists(lists)
    fmt.Println(r)
}

// https://leetcode.com/problems/merge-k-sorted-lists
func mergeKLists(lists []*ListNode) *ListNode {
    if lists == nil {
        return &ListNode{}
    }

    var newNode *ListNode = &ListNode{Val: math.MaxInt32} 
    var ptr = newNode

    var found = true
    var min = ptr.Val
    var minIndex = 0

    for found {
        found = false
        min = math.MaxInt32

        for i := 0; i < len(lists); i++ {
            if lists[i] == nil {
                continue
            }

            if lists[i] != nil {
                found = true

                if lists[i].Val < min {
                    min = lists[i].Val
                    minIndex = i
                }
            }
        }
        if found {
            ptr.Next = &ListNode{Val: lists[minIndex].Val}
            ptr = ptr.Next

            lists[minIndex] = lists[minIndex].Next
        }
    }

    return newNode.Next
}


func Min(a, b int) int {
    if a < b {
        return a
    }
    return b
}
