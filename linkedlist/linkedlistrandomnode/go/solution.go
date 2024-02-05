package main

import "math/rand"

type ListNode struct {
    Val int
    Next *ListNode
}

func main() {
}

// 1: If there's only one node -> return head
// 2: Possibility of picking 2nd node is 1/2
// 3: 1/3 (Generate a random number between 1-3, and if it's 3, replace it)
// 4: 1/4:  
// (Generate a random number between 1-4, and if it's 4, replace it)
type Solution struct {
    head *ListNode
}


func Constructor(head *ListNode) Solution {
    return Solution{head: head}
}


func (this *Solution) GetRandom() int {
    if this.head.Next == nil {
        return this.head.Val
    }

    var val = this.head.Val
    var ptr = this.head
    
    for i := 1; ptr != nil; i++ {
        
        ptr = ptr.Next
        rnd := rand.Intn(i)

        if rnd == i {
            val = ptr.Val
        }
    }


    return val
}

