package main

import (
	"fmt"
	"math"
	"strings"
)

func main() {
    s := "aacecaaa"
    r := shortestPalindrome(s)
    fmt.Println(r)
}

type PalindromeBoundary struct {
    start int
    end int
    length int
}

// https://leetcode.com/problems/shortest-palindrome
func shortestPalindrome(s string) string {

    if len(s) == 0 {
        return ""
    }

    var longestPalindromeLength = math.MinInt32
    var longestPalindrome *PalindromeBoundary 

    // Step 1: Attempt to find a palindrome
    for i := 0; i <= len(s) / 2; i++ {
        // case 1
        case1 := expand(s, i, i)
        case2 := expand(s, i, i + 1)

        if case1.start == 0 {
            // we've got a hit!
            // Get the characters that come after the palindrome and add them in
            // reverse order

            if case1.length > longestPalindromeLength {
                longestPalindrome = &case1
                longestPalindromeLength = case1.length
            }
        }

        if case2.start == 0 {
            // we've got a hit!
            // Get the characters that come after the palindrome and add them in
            // reverse order

            if case2.length > longestPalindromeLength {
                longestPalindrome = &case2
                longestPalindromeLength = case2.length
            }

        }
    }


    // Step 2: Build the result string
    // In the worst case longest palindrome will be
    // start: 0
    // end: 0 
    // length: 1
    // s := "bcd[aabaa]dcb"
    // longestPalindrome
    // start: 0
    // end: 4
    // length: 5

    var sb strings.Builder

    for i := longestPalindrome.end + 1; i < len(s); i++ {
        sb.WriteByte(s[i])
    }

    var end = sb.String()
    sb.Reset()

    for i := len(s) - 1; i >= longestPalindrome.end + 1; i-- {
        sb.WriteByte(s[i])
    }

    var start = sb.String()
    sb.Reset()

    // Write start
    sb.WriteString(start)


    // Write longest palindrome
    for i := longestPalindrome.start; i <= longestPalindrome.end; i++ {
        sb.WriteByte(s[i])
    }

    // Write end
    sb.WriteString(end)

    return sb.String()
}

// takes start and end, 
// expands as long as we maintain the properties of a palindrome
// returns the window

// abcd
// left: a
// right: a
func expand(s string, left int, right int) PalindromeBoundary {

    if right >= len(s) || s[left] != s[right] {
        return PalindromeBoundary{start: -1, end: -1}
    }

    for left >= 0 && right < len(s) && s[left] == s[right] {
        left--
        right++
    }

    return PalindromeBoundary{start: left + 1, end: right - 1, length: (right - 1) - (left + 1) + 1}
}

func Max(a int, b int) int {
    if a >= b {
        return a
    }
    return b
}



