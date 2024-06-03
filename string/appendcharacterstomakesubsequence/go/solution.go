package main

import "fmt"

func main() {
    s := "coaching"
    t := "coding"

    r := appendCharacters(s, t)
    fmt.Println(r)
}

// https://leetcode.com/problems/append-characters-to-string-to-make-subsequence
func appendCharacters(s string, t string) int {

    var result = 0;
    var sPtr = 0;

    for i := 0; i < len(t); i++ {

        if sPtr >= len(s) {
            result += len(t) - i;
            return result;
        }

        var searchFor = t[i]

        // they're equal, move on to the next character of 't'
        if s[sPtr] == searchFor {
            sPtr++;
            continue;
        }

        // they're not equal
        for sPtr < len(s) && s[sPtr] != searchFor {
            sPtr++
        }

        // did we run out of space in s?
        if sPtr >= len(s) {
            result += len(t) - i
            return result;
        }


        // we found the character in s - no need to add something
        sPtr++;
    }

    return result;
}
