package main

//https://leetcode.com/problems/check-if-the-sentence-is-pangram/
func main() {
}

func checkIfPangram(sentence string) bool {
	var alphabet []int = make([]int, 26)

	var left = 26

	for i := 0; i < len(sentence); i++ {
		var idx = sentence[i] - 'a'

		if alphabet[idx] == 1 {
			continue
		}
		alphabet[idx] = 1
		left--

		if left == 0 {
			return true
		}
	}

	return false
}
