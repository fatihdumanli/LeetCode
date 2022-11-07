package main

import "fmt"

//https://leetcode.com/problems/remove-colored-pieces-if-both-neighbors-are-the-same-color/
func main() {
	s := "AAAABBBB"
	r := winnerOfGame(s)
	fmt.Println(r)
}

// Sliding windows is overkill for this problem, instead,
// We gotta count the number of A's and B's.
// When we think a bunch of character set as a window,
// There must at least be 1 character between first the last (AAA, BBB)
// So, for each window, we subtract the edges from the  length of the window. (3 - 2) = 2 (3 - 2) = 1
// Since Alice is the one who starts to play, the A's gotta be greater than B's for us to return true.
func winnerOfGame(colors string) bool {
	
	if len(colors) < 3 {
		return false
	}
	var a int
	var b int
	var mem byte = colors[0]
	var cnt = 1


	for i := 1; i < len(colors); i++ {

		if colors[i] != mem {
			if cnt > 2 {
				if mem == 65 {
					a += cnt - 2
				} else {
					b += cnt - 2
				}
			}
			mem = colors[i]
			cnt = 1
			continue
		}

		cnt++
	}
	
	//leftover
	if cnt > 2 {
		if mem == 65 {
			a += cnt - 2
		} else {
			b += cnt - 2
		}
	}

	return a > b
}
