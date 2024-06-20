package main

import "fmt"
import "math"

func main() {
    //var bloomDay = []int{30,49,11,66,54,22,2,57,35}
    //var m = 3; 
    //var k = 3;

    //var bloomDay = []int{62,75,98,63,47,65,51,87,22,27,73,92,76,44,13,90,100,85};
    //var m = 2;
    //var k = 7;

    var bloomDay = []int{7,4,3,10,5,2,8,9};
    var m = 2;
    var k = 3;

    var r = minDays(bloomDay, m, k);

    fmt.Println(r);
}

// https://leetcode.com/problems/minimum-number-of-days-to-make-m-bouquets
func minDays(bloomDay []int, m int, k int) int {
    if len(bloomDay) < m * k {
        return -1;
    }

    var minDays = getMin(bloomDay);
    var maxDays = getMax(bloomDay);

    var flowersCollected = 0;
    var bouqetsCollected = 0;


    var start = minDays;
    var end = maxDays;

    for start <= end {

        var mid = start + ((end - start) / 2);

        for i := 0; i < len(bloomDay); i++ {
            var val = bloomDay[i];

            if val <= mid {
                flowersCollected++;
            } else {
                flowersCollected = 0;
            }

            if flowersCollected == k {
                bouqetsCollected++;
                flowersCollected = 0;
            }

            if bouqetsCollected == m {
                break;
            }
        }
        // if we were able to collect the bouquest, we attempt to 

        // seek a lower value
        // otherwise, a higher value
        if bouqetsCollected >= m {
            end = mid - 1;
            flowersCollected = 0;
            bouqetsCollected = 0;
        } else {
            start = mid + 1;
            flowersCollected = 0;
            bouqetsCollected = 0;
        }
    }

    return start;
}


func getMin(arr []int) int {
    var min = math.MaxInt32
    for i := 0; i < len(arr); i++ {
        min = Min(min, arr[i]);
    }

    return min;
}

func getMax(arr []int) int {
    var max = math.MinInt32
    for i := 0; i < len(arr); i++ {
        max = Max(max, arr[i]);
    }

    return max;
}
func Min(a, b int) int {
    if a <= b {
        return a;
    }
    return b;
}

func Max(a, b int) int {
    if a >= b {
        return a;
    }
    return b;
}

