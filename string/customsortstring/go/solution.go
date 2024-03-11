package main

import "fmt"
import "strings"

func main() {
    order := "bcafg"
    s := "abcdb"

    r := customSortString(order, s)
    fmt.Println(r)
}

// https://leetcode.com/problems/custom-sort-string
func customSortString(order string, s string) string {

    // Convert the string into byte array to enable char manipulation
    var strBytes = []byte(s)

    // Map that stores the each char and their locations
    // For the string "abcdb"; the map will be formed in the following format
    // a -> [0]
    // b -> [1, 4]
    // c -> [2]
    // d -> [3]
    var locationMap = make(map[byte][]int)

    for i := 0; i < len(s); i++ {
        var char = s[i]

        if _, ok := locationMap[char]; ok {
            locationMap[char] = append(locationMap[char], i)
        } else {
            locationMap[char] = []int{i}
        }
    }

    var sb = strings.Builder{}

    // Go through the chars in the order and check if we have them in 's'
    for i := 0; i < len(order); i++ {
        var char = order[i]

        if locations, ok := locationMap[char]; ok {
            // Check how many 'char' appears in s
            removeChars(strBytes, locations)

            appendChars(&sb, char, len(locations))
        }     
    }


    // Append the rest of the chars in the 's'
    for i := 0; i < len(strBytes); i++ {
        if strBytes[i] == 'X' {
            continue
        }
        sb.WriteByte(strBytes[i])
    }

    return sb.String()
}

// function that removes the given characters from the string
// removing is simulation - this function replaces the character with 'X'
func removeChars(strBytes []byte, locations []int) {
    for i := 0; i < len(locations); i++ {
        strBytes[locations[i]] = 'X'
    }
}

// appends given char 'times' times into the given string builder
func appendChars(sb *strings.Builder, char byte, times int) {
    for i := 0; i < times; i++ {
        sb.WriteByte(char)
    }
}






