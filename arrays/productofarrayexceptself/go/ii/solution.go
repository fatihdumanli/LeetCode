package main

import "fmt"

func main() {
    var nums = []int{1,2,3,4}
    r := productExceptSelf(nums)
    fmt.Println(r)
}

// https://leetcode.com/problems/product-of-array-except-self
func productExceptSelf(nums []int) []int {

    // [1, 2, 3, 4]


    // [1, 2, 6, 24]
    // [24,24,12,4]

    var pre = []int{}
    var product = 1

    for i := 0; i < len(nums); i++ {
        var num = nums[i]
        product = product * num
        pre = append(pre, product)
    }


    var post = make([]int, len(nums))

    product = 1
    for i := len(nums) - 1; i >= 0; i-- {
        var num = nums[i]

        product = product * num
        post[i] = product
    }

    var getPre = func(i int) int {
        if i == 0 {
            return 1
        }
        return pre[i - 1]
    }

    var getPost = func(i int) int {
        if i == len(nums) - 1 {
            return 1
        }
        return post[i + 1]
    }

    var result []int

    for i := 0; i < len(nums); i++ {
        var r = getPre(i) * getPost(i)
        result = append(result, r)
    }

    return result
}
