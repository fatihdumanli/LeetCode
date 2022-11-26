package main

import (
	"fmt"
	"sort"
)

//https://leetcode.com/problems/find-players-with-zero-or-one-losses/
func main() {
	matches := [][]int{{1, 3}, {2, 3}, {3, 6}, {5, 6}, {5, 7}, {4, 5}, {4, 8}, {4, 9}, {10, 4}, {10, 9}}
	r := findWinners(matches)
	fmt.Println(r)
}

func findWinners(matches [][]int) [][]int {
	//key is the player and the value is the number of times the player has lost
	var scoreboard map[int]int = make(map[int]int)
	var zeroLoss []int
	var oneLoss []int

	for i := 0; i < len(matches); i++ {
		winner := matches[i][0]
		loser := matches[i][1]

		if _, ok := scoreboard[loser]; !ok {
			scoreboard[loser] = 0
		}

		if _, ok := scoreboard[winner]; !ok {
			scoreboard[winner] = 0
		}
	}

	for i := 0; i < len(matches); i++ {
		loser := matches[i][1]
		scoreboard[loser]++
	}

	for k, v := range scoreboard {
		if v == 0 {
			zeroLoss = append(zeroLoss, k)
		}

		if v == 1 {
			oneLoss = append(oneLoss, k)
		}
	}

	sort.Ints(zeroLoss)
	sort.Ints(oneLoss)

	return [][]int{zeroLoss, oneLoss}
}
