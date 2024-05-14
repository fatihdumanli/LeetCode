package main

import "math/rand"
import "fmt"

func main() {
    arr := []int{ 10,30,90,110,70,60,80,120,50,40 }

    r := quickSort(arr)
    fmt.Println(r)
}
func random(low, hi int) int {
    return low + rand.Intn(hi-low)
}


func merge(a []int, b []int) []int {
    var c = make([]int, len(a) + len(b))

    var ptr = 0
    for i := 0; i < len(a); i++ {
        c[ptr] = a[i]
        ptr++
    }

    for i := 0; i < len(b); i++ {
        c[ptr] = b[i]
        ptr++
    }

    return c;
}

func mergeWithPivot(a []int, num int) []int {
    var merged = make([]int, len(a) + 1)
    var ptr = 0
    for i := 0; i < len(a); i++ {
        merged[ptr] = a[i]
        ptr++
    }
    merged[ptr] = num

    return merged
}

func quickSort(arr []int) []int {
    if len(arr) <= 1 {
        return arr
    }

    var left = []int{}
    var right = []int{}

    var pivotIdx = random(0, len(arr) - 1)
    var pivot = arr[pivotIdx]

    for i := 0; i < len(arr); i++ {
        var num = arr[i]

        if i == pivotIdx {
            continue
        }

        if num <= pivot {
            left = append(left, num)
        } else if (num > pivot) {
            right = append(right, num)
        }
    }

    var leftSorted = quickSort(left)
    var mergedWithLeft = mergeWithPivot(leftSorted, pivot)
    var rightSorted = quickSort(right)

    return merge(mergedWithLeft, rightSorted)
}
