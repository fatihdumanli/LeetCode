package main

import "fmt"

func main() {
	fmt.Println(reverseBits(1))
}

func reverseBits(num uint32) uint32 {

	var m uint32 = 0
	var one uint32 = 1

	for i := 0; i < 32; i++ {

		//get the value of cur bit
		var curBit uint32 = num & one
		//shift m to the left
		m <<= 1
		//merge curBit with m
		m = m | curBit

		num >>= 1
	}

	return m

	//	for i := 0; i < 16; i++ {
	//		var left bool = getBit(num, 31-i)
	//		var right bool = getBit(num, i)
	//		num = updateBit(num, 31-i, right)
	//		num = updateBit(num, i, left)
	//	}
	//	return num
}

func clearBit(num uint32, i int) uint32 {
	var one uint32 = 1
	one <<= i
	var mask uint32 = ^one
	return num & mask
}
func updateBit(num uint32, i int, val bool) uint32 {
	num = clearBit(num, i)
	var v uint32
	if val {
		v = 1
	} else {
		v = 0
	}
	v <<= i
	return v | num
}

func getBit(num uint32, i int) bool {
	var one uint32 = 1
	one <<= i
	return num&one != 0
}
