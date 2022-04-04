package main

import (
	"fmt"
	"strings"
)

func main() {
	number := "9964-"
	fmt.Println(reformatNumber(number))
}

func reformatNumber(number string) string {
	var sb strings.Builder = strings.Builder{}

	for i := 0; i < len(number); i++ {
		if isDigit(number[i]) {
			sb.WriteByte(number[i])
		}
	}
	newNumber := sb.String()
	sb.Reset()

	var rem = len(newNumber)

	var i int = 0
	if rem > 4 {
		var totalNumbers int
		for ; i < len(newNumber); i++ {
			sb.WriteByte(newNumber[i])
			totalNumbers++
			rem--
			if totalNumbers%3 == 0 {
				sb.WriteString("-")
				if rem <= 4 {
					i++
					break
				}
			}
		}
	}

	switch rem {
	case 4:
		sb.WriteByte(newNumber[i])
		sb.WriteByte(newNumber[i+1])
		sb.WriteString("-")
		sb.WriteByte(newNumber[i+2])
		sb.WriteByte(newNumber[i+3])
	case 3:
		sb.WriteByte(newNumber[i])
		sb.WriteByte(newNumber[i+1])
		sb.WriteByte(newNumber[i+2])

	case 2:
		sb.WriteByte(newNumber[i])
		sb.WriteByte(newNumber[i+1])

	}

	return sb.String()
}

func isDigit(x byte) bool {
	return x >= '0' && x <= '9'
}
