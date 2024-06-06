package main

import (
	"fmt"
	"sort"
)

func main() {
    var hand = []int{1,2,3,6,2,3,4,7,8};
    var r = isNStraightHand(hand, 3);
    fmt.Println(r);
}

// https://leetcode.com/problems/hand-of-straights
func isNStraightHand(hand []int, groupSize int) bool {

    if len(hand) % groupSize != 0 {
        return false;
    }

    sort.Slice(hand, func (i, j int) bool {
        return hand[i] < hand[j];
    });

    var groupNeeded = len(hand) / groupSize;
    var groupCounter = 0;

    var ptr = 0;
    var currentGroup = 1;

    var lastMinPtr = 0;

    for groupCounter < groupNeeded {

        ptr = lastMinPtr;

        currentGroup = 1;
        for ptr < len(hand) && hand[ptr] == -1 {
            ptr++;
        }

        var currentNumber = hand[ptr];
        hand[ptr] = -1;
        
        for currentGroup < groupSize {
            if ok, idx := searchNumber(hand, ptr + 1, currentNumber + 1); ok {
                currentGroup++;
                currentNumber++;
                hand[idx] = -1;
                ptr = idx;
            } else {
                return false;
            }
        }

        groupCounter++;
    }

    return true;
}

func searchNumber(hand []int, startIndex int, searchFor int) (bool, int) {

    for i := startIndex; i < len(hand); i++ {
        if hand[i] == searchFor {
            return true, i;
        }
    }

    return false, -1;
}
