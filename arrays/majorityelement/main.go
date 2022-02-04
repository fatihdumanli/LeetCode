package main

 

import (

        "fmt")

 

func main() {

        nums := []int { 2,2,1,1,1,2,2 }

        result := majorityElement(nums)

        fmt.Println(result)

}

 

func majorityElement(nums []int) int {
        hashmap := make(map[int]int)

        for i := 0; i < len(nums); i++ {
                isExist := hashmap[nums[i]]
                if isExist == 0 {
                        hashmap[nums[i]] = 1
                } else {
                        hashmap[nums[i]]++
                }

                if hashmap[nums[i]] == (len(nums) / 2) + 1 {
                        return nums[i]
                }
        }
        return 0
}













