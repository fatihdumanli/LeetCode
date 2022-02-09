package main

import "fmt"

func main() {
	var num uint16 = 7000
	res := maxSequenceOfOnes(num)
	fmt.Println(res)
}

//num: 0001 1011 0101 1000 (7000)
func maxSequenceOfOnes(num uint16) int {
	var tolerate int = 1
	var n int
	var maxWindow int

	var numStr = fmt.Sprintf("%016b", num)
	_ = numStr

	for i := 0; i < 16; i++ {
		var isItOne = getithBitValue(num, i)
		if !isItOne && n > 0 {
			if tolerate == 0 {
				maxWindow = Max(maxWindow, n)
				n = 0
				tolerate = 1
			} else {
				tolerate--
				n++
			}
		}

		if isItOne {
			n++
		}

	}
	return maxWindow
}

func getithBitValue(num uint16, i int) bool {
	var mask uint16 = 1
	mask = mask << i
	return num&mask != 0
}

func Max(a, b int) int {
	if a > b {
		return a
	} else {
		return b
	}
}
