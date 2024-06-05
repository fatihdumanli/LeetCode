package main

import (
	"fmt"
)

func main() {
    s1 := "ab";
    s2 := "eidbaoo";


    r := checkInclusion(s1, s2);

    fmt.Println(r);
}

// https://leetcode.com/problems/permutation-in-string
func checkInclusion(s1 string, s2 string) bool {

    var freq = make([]int, 26);

    for i := 0; i < len(s1); i++ {
        var ascii = s1[i];
        freq[ascii - 97]++;
    }

    var left = 0;
    var right = len(s1) - 1;

    for right < len(s2) {

        var substring = s2[left:right + 1];
        var freqCopy = make([]int, 26);
        copy(freqCopy, freq);

        if isAnagram(substring, freqCopy) {
            return true;
        }

        right++;
        left++;
    }

    return false;
}

func isAnagram(s1 string, freq []int) bool {

    for i := 0; i < len(s1); i++ {
        var char = s1[i];
        freq[char - 97]--;
    }

    for i := 0; i < 26; i++ {
        if freq[i] != 0 {
            return false;
        }
    }

    return true;
}

