package main

import "fmt"

// https://leetcode.com/problems/time-needed-to-inform-all-employees
type OrganizationTreeNode struct {
    Id int
    TimeNeededToInformEmployees int
    Employees []*OrganizationTreeNode
}

type MyListNode struct {
    Val *OrganizationTreeNode
    Next *MyListNode
}

type Queue struct {
    Length int
    head *MyListNode
}

func (q *Queue) Enqueue(val *OrganizationTreeNode) {
    q.Length++
    if q.head == nil {
        q.head = &MyListNode{Val: val}
        return
    }

    var ptr = q.head

    for ptr.Next != nil {
        ptr = ptr.Next
    }

    ptr.Next = &MyListNode{Val: val}
}

func (q *Queue) Dequeue() *OrganizationTreeNode {
    if q.head == nil {
        return nil
    }

    var temp = q.head.Val
    q.head = q.head.Next

    q.Length--

    return temp
}

func main() {
    n := 9
    headID := 0
    manager := []int{-1,0,1,2,3,4,0,6,7}
    informTime := []int{5,2,20,2,2,0,10,9,0}

    r := numOfMinutes(n, headID, manager, informTime)
    fmt.Println(r)
}

func numOfMinutes(n int, headID int, manager []int, informTime []int) int {

    var employeesByManager map[int][]int = make(map[int][]int)

    for i := 0; i < n; i++ {
        var id = i
        var manager = manager[i]
        employeesByManager[manager] = append(employeesByManager[manager], id)
    }

    var root = &OrganizationTreeNode{Id: headID, TimeNeededToInformEmployees: informTime[headID], Employees: []*OrganizationTreeNode{}}

    var queue = &Queue{}
    queue.Enqueue(root)


    for queue.Length > 0 {
        var ptr = queue.Dequeue()

        var childrenIds = employeesByManager[ptr.Id]

        for i := 0; i < len(childrenIds); i++ {
            var id = childrenIds[i]

            var node = &OrganizationTreeNode{Id: id, TimeNeededToInformEmployees: informTime[id], Employees: []*OrganizationTreeNode{}}
            ptr.Employees = append(ptr.Employees, node)
            queue.Enqueue(node)
        }
    }


    // Now, we need to find the maximum path
    var result = intp(0)

    traversePath(root, 0, result)

    return *result
}

func traversePath(root *OrganizationTreeNode, sum int, result *int) {

    if len(root.Employees) == 0 {
        return
    }

    sum += root.TimeNeededToInformEmployees

    *result = Max(*result, sum)

    var children = root.Employees

    for i := 0; i < len(children); i++ {
        var c = children[i]

        traversePath(c, sum, result)
    }

}

func Max(a, b int) int {
    if a > b {
        return a
    }
    return b
}

func intp(x int) *int {
    return &x
}




