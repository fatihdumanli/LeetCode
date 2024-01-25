package main

import "fmt"

func main() {
    digits := "234"
    r := letterCombinations(digits)

    fmt.Println(r)
}

func letterCombinations(digits string) []string {

    var hashmap = make(map[int][]int)
    hashmap['2'] = []int{'a','b','c'}
    hashmap['3'] = []int{'d','e','f'}
    hashmap['4'] = []int{'g','h','i'}
    hashmap['5'] = []int{'j','k','l'}
    hashmap['6'] = []int{'m','n','o'}
    hashmap['7'] = []int{'p','q','r', 's'}
    hashmap['8'] = []int{'t','u','v'}
    hashmap['9'] = []int{'w','x','y', 'z'}

    var result = &[]string{}
    combine(digits, "", 0, hashmap, result) 

    return *result
}

func combine(digits string, prefix string, index int, hashmap map[int][]int, result *[]string) {
    if index >= len(digits) {
        if prefix == "" {
            return
        }
        *result = append(*result, prefix)
        return
    }

    var nextDigit = digits[index]
    var letters = hashmap[int(nextDigit)]

    for i := 0; i < len(letters); i++ {

        var temprefix = prefix
        prefix += string(rune(letters[i]))

        combine(digits, prefix, index + 1, hashmap, result)

        prefix = temprefix
    }

}
