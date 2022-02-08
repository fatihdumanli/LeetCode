package main

import "fmt"

func main() {

	//
	var n uint8 = uint8(154)
	var m uint8 = uint8(7)
	var j uint8 = 5
	var i uint8 = 3
	res := updateBits(n, m, j, i)
	fmt.Printf("%08b", res)
}

func updateBits(n uint8, m uint8, j uint8, i uint8) uint8 {
	if i > j || i < 0 || j >= 32 {
		return 0
	}

	//n: 1001 1010
	//m: 0000 0111
	//j:5, i:3
	var allOnes uint8
	allOnes = ^uint8(0)

	//left:  1100 0000
	var left uint8 = allOnes<<j + 1
	//right: 0000 0111
	var right uint8 = (1 << i) - 1
	//mask:  1100 0111
	var mask = left | right

	//n_cleared: 1000 0010
	var n_cleared uint8 = mask & n
	//shift m to the right position before merging
	//m_shifted: 0011 1000
	var m_shifted = m << i
	//merge and return them
	//1011 1010
	return n_cleared | m_shifted
}
