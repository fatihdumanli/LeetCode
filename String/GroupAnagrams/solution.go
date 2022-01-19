package main

import (
	"fmt"
)

func main() {
	var strs = []string{"eat", "tea", "tan", "ate", "nat", "bat"}
	res := groupAnagrams(strs)

	var testArray []string
	testArray = append(testArray, "fdsaf")
	fmt.Println(res)
}

func groupAnagrams(strs []string) [][]string {

	hashmap := map[[26]int][]string{}
	for _, str := range strs {
		var freq [26]int
		for i := 0; i < len(str); i++ {
			freq[str[i]-'a']++
		}
		hashmap[freq] = append(hashmap[freq], str)
	}

	var result [][]string
	for _, v := range hashmap {
		result = append(result, v)
	}
	return result
}
