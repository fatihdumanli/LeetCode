package main

import "fmt"

func main() {
	var res = hammingWeight(3)
	fmt.Println(res)
}

func hammingWeight(num uint32) int {
	var count int = 0

	//num     : 1010
	//num >> 1: 0101
	//num >> 2: 0010
	//num >> 3: 0001
	//num >> 4: 0000
	//1       : 0001

	for num > 0 {
		count += int(num & 1)
		num >>= 1
	}

	return count
}
