package main

import "fmt"

func main() {
    var s = "aaaccc";
    s = "AAAAAA";
    // dcccd
    r := longestPalindrome2(s);
    fmt.Println(r);
}

// without hashmap
func longestPalindrome2(s string) int {

    var result = 0;
    var freq = make([]int, 26);
    var freqUpperCase = make([]int, 26);

    for i := 0; i < len(s); i++ {

        var ascii = int(s[i]);

        if ascii >= 97 {
            if freq[ascii - 97] == 1 {
                freq[ascii - 97] = 0;
                result += 2;
                continue;
            } 

            freq[ascii - 97] = 1;
            continue;
        }

        // uppercase
        if freqUpperCase[ascii - 65] == 1 {
            freqUpperCase[ascii - 65] = 0;
            result += 2;
            continue;
        }

        freqUpperCase[ascii - 65] = 1;
    }

    var add = 0;
    for i := 0; i < len(freq); i++ {
        if freq[i] > 0 || freqUpperCase[i] > 0 {
            add = 1;
        }
    }

    return result + add;
}


// https://leetcode.com/problems/longest-palindrome/
// Note that the even if the frequence of a character is ODD,
// It can still contribute to the longest palindrome.
// If we subtract 1 from it's odd frequency, what we'll end up with is 
// a set of characters which can pair up. (The freq will be 2x - even).
// So we don't ignore the odd occurences, we subtact 1 and add it to the result
// set.
func longestPalindrome(s string) int {

    if len(s) == 1 {
        return 1;
    }

    var result = 0;
    var freq map[byte]int = make(map[byte]int)

    for i := 0; i < len(s); i++ {
        var c = s[i];

        if _, ok := freq[c]; ok {
            freq[c]++;
        } else {
            freq[c] = 1;
        }
    }

    var spareOneCharFactor = 0;
    for _, v := range freq {

        if v % 2 == 1 {
            result += v - 1
            spareOneCharFactor = 1;
            continue;
        }

        if v % 2 == 0 {
            result += v
        }
    }

    return result + spareOneCharFactor;
}

