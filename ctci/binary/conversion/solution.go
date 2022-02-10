package main

import "fmt"

func main() {

	//6:     0110
	//9:     1001
	//6 ^ 9: 1111
	fmt.Println(conversion(6, 3))
}

//Num of bits needs to be flipped to convert a to b
func conversion(a, b uint16) uint16 {

	var c uint16 = a ^ b
	var count uint16

	for c > 0 {
		count += c & 1
		c >>= 1
	}

	return count
}
