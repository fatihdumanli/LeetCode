package main

import "fmt"
import "sort"

func main() {
    // var nums = []int{1,1,2,2,4,5}
    // var nums = []int{1,1,2,2}
    var nums = []int{1,1,2,2,4,5,7}
    var r = minIncrementForUnique(nums);
    fmt.Println(r);
}


// https://leetcode.com/problems/minimum-increment-to-make-array-unique/
type MyListNode struct {
    Val int
    Next *MyListNode
}

type Queue struct {
    head *MyListNode
}

func (q *Queue) isEmpty() bool {
    return q.head == nil;
}

func (q *Queue) enqueue(val int) {
    if q.head == nil {
        q.head = &MyListNode{Val: val}
        return;
    }

    var newHead = &MyListNode{Val: val}
    newHead.Next = q.head;
    q.head = newHead;
}

func (q *Queue) dequeue() int {
    if q.head == nil {
        panic("no element in queue");
    }

    var val = q.head.Val;
    q.head = q.head.Next;

    return val;
}

func minIncrementForUnique(nums []int) int {

    if len(nums) == 1 {
        return 0;
    }

    sort.Slice(nums, func(i, j int) bool {
        return nums[i] <= nums[j];
    });

    var queue = &Queue{}

    var result = 0;

    for i := 1; i < len(nums); i++ {

        if nums[i] == nums[i - 1] {
            queue.enqueue(nums[i]);
            continue;
        }

        // fill the gaps
        if nums[i] - nums[i - 1] > 1 {
            // gap = [nums[i - 1] + 1, nums[i] - 1]
            var currentGap = nums[i - 1] + 1;

            for !queue.isEmpty() && currentGap < nums[i] {
                var val = queue.dequeue();
                var diff = currentGap - val;
                result += diff;
                currentGap++;
            }
        }
    }

    var currentGap = nums[len(nums) - 1] + 1;

    for !queue.isEmpty() {
        var val = queue.dequeue();
        var diff = currentGap - val;
        result += diff;
        currentGap++;
    }

    return result;
}
