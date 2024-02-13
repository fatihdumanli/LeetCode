package main

import "fmt"

type ListNode struct {
    Val int
    Next *ListNode
}

func main() {
    // head := &ListNode{Val: 4, Next: &ListNode{Val: 3, Next: &ListNode{Val: 2, Next: &ListNode{Val: -2, Next: &ListNode{Val: -2, Next: &ListNode{Val: 4, Next: &ListNode{Val: -2}}}}}}}
    head := &ListNode{Val: 0}
    r := removeZeroSumSublists(head)
    fmt.Println(r)
}

// https://leetcode.com/problems/remove-zero-sum-consecutive-nodes-from-linked-list
var DELETED_NODE = 5000
func removeZeroSumSublists(head *ListNode) *ListNode {
    var ptr = head
    var cnt = 0 
    var sumArr []int
    var zeroIndex = -1

    for ptr != nil {
        sumArr, zeroIndex = fillSumArr(sumArr, cnt, ptr.Val)

        if zeroIndex != -1 {
            // modify sumArr
            sumArr = disableRemovedNodeSums(sumArr, zeroIndex, cnt)

            // modify linked list
            disableRemovedNodes(head, zeroIndex, cnt)
        }

        ptr = ptr.Next
        cnt++
    }

    // Build new listNode
    var newHead *ListNode = &ListNode{Val: 0}
    var ptr2 = newHead
    ptr = head

    for ptr != nil {
        if ptr.Val != 5000 {
            ptr2.Next = &ListNode{Val: ptr.Val}
            ptr2 = ptr2.Next
        }
        ptr = ptr.Next
    }

    return newHead.Next
}

func disableRemovedNodes(head *ListNode, start int, end int) {
    var numOfRemovedNodes = end - start + 1
    var ptr = head

    for i := 0; i < start; i++ {
        ptr = ptr.Next
    }

    for i := 0; i < numOfRemovedNodes; i++ {
        ptr.Val = DELETED_NODE
        ptr = ptr.Next
    }
}

func disableRemovedNodeSums(sumArr []int, start int, end int) []int {
    for i := start; i <= end; i++ {
        sumArr[i] = DELETED_NODE
    }
    return sumArr
}

func fillSumArr(sumArr []int, cnt int, val int) ([]int, int) {

    var zeroIndex int = -1

    if val == 0 {
        zeroIndex = cnt
    }
    sumArr = append(sumArr, val)
    for i := 0; i < cnt; i++ {
        if sumArr[i] == DELETED_NODE {
            continue
        }
        sumArr[i] = sumArr[i] + val
        if sumArr[i] == 0 {
            zeroIndex = i
        }
    }

    return sumArr, zeroIndex
}

