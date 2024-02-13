package main

import "fmt"

type ListNode struct {
    Val int
    Next *ListNode
}

func main() {
    head := &ListNode{Val: 4, Next: &ListNode{Val: 3, Next: &ListNode{Val: 2, Next: &ListNode{Val: -2, Next: &ListNode{Val: -2, Next: &ListNode{Val: 4, Next: &ListNode{Val: -2}}}}}}}
    r := removeZeroSumSublists(head)
    fmt.Println(r)
}

// https://leetcode.com/problems/remove-zero-sum-consecutive-nodes-from-linked-list
var DELETED_NODE = 5000
func removeZeroSumSublists(head *ListNode) *ListNode {
    var ptr = head
    var cnt = 0 
    var sumArr []int

    for ptr != nil {
        sumArr = fillSumArr(sumArr, cnt, ptr.Val)

        r := searchZero(sumArr)

        if r != -1 {
            // modify sumArr
            sumArr = disableRemovedNodeSums(sumArr, r, cnt)

            // modify linked list
            disableRemovedNodes(head, r, cnt)
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

// returns the position of a zero if found
// -1 otherwise
func searchZero(sumArr []int) int {
    for i := 0; i < len(sumArr); i++ {
        if sumArr[i] == 0 {
            return i
        }
    }

    return -1
}

func fillSumArr(sumArr []int, cnt int, val int) []int {

    sumArr = append(sumArr, val)
    for i := 0; i < cnt; i++ {
        if sumArr[i] == DELETED_NODE {
            continue
        }
        sumArr[i] = sumArr[i] + val
    }
    return sumArr
}

