package main

import "fmt"

func main() {

    nums := []int{1,3,2,2,5,2,3,7}
    //nums = []int{1,1,1,1}
    // nums = []int{1,3,2,2,5,2,4,3,34,5,3,4,2,4,5,3,2,1,3,4,6,3,2,1,4,3,5,6,8,9,5,3,4,2,1,4,6,3,7}

    r := findLHS(nums)

    fmt.Println(r)
}

type sequence struct {
    count int
    min int
    max int
}

// https://leetcode.com/problems/longest-harmonious-subsequence/
func findLHS(nums []int) int {

    var result = 0
    var min = make(map[int]*sequence)
    var max = make(map[int]*sequence)

    for i := 0; i < len(nums); i++ {
        var num = nums[i]

        /*

            -> If the number did not appear before

            1. Add it to the min hashmap [1, num, num]
            2. Add it to the max hashmap [1, num, num]


            3 things we need to do for each number.

            1. Search num - 1 in the min hashmap
               
               Increase count by 1, 
               Evaluate min, 
               Evaluate max

            2. Search num + 1 in the max hashmap
                
               Increase count by 1.
               Evaluate min
               Evaluate max

            3. If the number appeared before, (it's in both min and max hashmaps)

               Increase count by 1 in min hashmap
               Increase count by 1 in max hasmap
        */

        _, ok := min[num];
        if !ok {
            min[num] = &sequence{count: 1, min: num, max: num}
            max[num] = &sequence{count: 1, min: num, max: num}
        } else {
            min[num].count++
            max[num].count++

            if min[num].min != min[num].max {
                result = Max(result, min[num].count)
            }

            if max[num].min != max[num].max {
                result = Max(result, max[num].count)
            }
        }

        if _, ok := min[num - 1]; ok {
            min[num - 1].count++
            min[num - 1].min = Min(min[num - 1].min, num)
            min[num - 1].max = Max(min[num - 1].max, num)

            if min[num - 1].min != min[num - 1].max {
                result = Max(result, min[num - 1].count)
            }
        }
        
        if _, ok := max[num + 1]; ok {
            max[num + 1].count++
            max[num + 1].min = Min(max[num + 1].min, num)
            max[num + 1].max = Max(max[num + 1].max, num)

            if max[num + 1].min != max[num + 1].max {
                result = Max(result, max[num + 1].count)
            }
        }

    }

    return result
}


func Abs(x int) int {
    if x < 0 {
        return (-1) * x
    } else if (x > 0) {
        return x
    }

    return 0
}

func intp(x int) *int {
    return &x
}

func Max(a, b int) int {
    if a > b {
        return a
    }
    return b
}

func Min(a, b int) int {
    if a < b {
        return a
    }
    return b
}
