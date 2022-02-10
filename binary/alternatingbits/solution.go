package main

import "fmt"

func main() {
	fmt.Println(hasAlternatingBits(5))
}

func hasAlternatingBits(n int) bool {

	var nStr = fmt.Sprintf("%032b", n)
	_ = nStr

	var a int = 0xAAAAAAAA
	var b int = 0x55555555

	aStr := fmt.Sprintf("%032b", a)
	bStr := fmt.Sprintf("%032b", b)
	_ = aStr
	_ = bStr

	x := n ^ a
	y := n ^ b

	xStr := fmt.Sprintf("%032b", x)
	yStr := fmt.Sprintf("%032b", y)
	_ = xStr
	_ = yStr

	return x == 0 || y == 0
}
