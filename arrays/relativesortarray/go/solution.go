package main

import "sort"
import "fmt"

func main() {
    //arr1 := []int{2,3,1,3,2,4,6,7,9,2,19}
    //arr2 := []int{2,1,4,3,9,6}

    arr1 := []int{28,6,22,8,44,17}
    arr2 := []int{22,28,8,6}

    r := relativeSortArrayWithBuckets(arr1, arr2);
    fmt.Println(r);
}


func relativeSortArrayWithBuckets(arr1 []int, arr2 []int) []int {

    var bucket = make([]int, 1001);

    for i := 0; i < len(arr1); i++ {
        var num = arr1[i];

        bucket[num]++;
    }

    var result = []int{}

    for i := 0; i < len(arr2); i++ {
        var num = arr2[i];

        for bucket[num] > 0 {
            result = append(result, num);
            bucket[num]--;
        }
    }

    for i := 0; i < len(bucket); i++ {
        for bucket[i] > 0 {
            result = append(result, i);
            bucket[i]--;
        }
    }

    return result;
}


// https://leetcode.com/problems/relative-sort-array
func relativeSortArray(arr1 []int, arr2 []int) []int {

    // key: number
    // value: frequency
    var hashmap map[int]int = make(map[int]int)

    // 1. Get the frequency array of the arr1
    for i := 0; i < len(arr1); i++ {

        var num = arr1[i];

        if _, ok := hashmap[num]; ok {
            hashmap[num]++;
        } else {
            hashmap[num] = 1;
        }
    }

    // 2. Find out the numbers in arr1 that does not appear in arr2
    var hashset = make(map[int]bool)

    for i := 0; i < len(arr2); i++ {
        var num = arr2[i];
        hashset[num] = true;
    }

    var arr1OnlyNumbers = []int{}

    for i := 0; i < len(arr1); i++ {
        var num = arr1[i];
        if _, ok := hashset[num]; !ok {
            arr1OnlyNumbers = append(arr1OnlyNumbers, num);
        }
    }

    var result = []int{}

    // 3. Iterate through arr2
    for i := 0; i < len(arr2); i++ {
        var num = arr2[i];
        var freq, _ = hashmap[num];

        for k := 0; k < freq; k++ {
            result = append(result, num);
        }
    }

    sort.Slice(arr1OnlyNumbers, func(i, j int) bool {
        return arr1OnlyNumbers[i] <= arr1OnlyNumbers[j];
    });

    for i := 0; i < len(arr1OnlyNumbers); i++ {
        var num = arr1OnlyNumbers[i];

        result = append(result, num);
    }

    return result
}
