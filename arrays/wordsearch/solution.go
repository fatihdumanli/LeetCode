package main

import "fmt"

func main() {

	var board = make([][]byte, 3)
	board[0] = make([]byte, 3)
	board[1] = make([]byte, 3)
	board[2] = make([]byte, 3)

	board[0] = []byte{'A', 'B', 'C'}
	board[1] = []byte{'D', 'E', 'F'}
	board[2] = []byte{'G', 'H', 'I'}

	fmt.Println(exist(board, "ABE"))
}

func exist(board [][]byte, word string) bool {
	for i := 0; i < len(board); i++ {
		for j := 0; j < len(board[0]); j++ {

			if word[:1] != string(board[i][j]) {
				continue
			}

			if dfs(board, i, j, 0, word, word[:1]) {
				return true
			}
		}
	}

	return false
}

func dfs(board [][]byte, row, col int, count int, target string, curTarget string) bool {
	if row < 0 || row >= len(board) {
		return false
	}

	if col < 0 || col >= len(board[0]) {
		return false
	}

	if string(board[row][col]) != curTarget {
		return false
	}

	if count == len(target)-1 {
		return true
	}

	var nextChar = target[count+1 : count+2]
	var temp = board[row][col]

	board[row][col] = 0
	//left
	left := dfs(board, row, col-1, count+1, target, nextChar)
	//right
	right := dfs(board, row, col+1, count+1, target, nextChar)
	//bottom
	bottom := dfs(board, row+1, col, count+1, target, nextChar)
	//top
	top := dfs(board, row-1, col, count+1, target, nextChar)
	board[row][col] = temp

	if left || right || top || bottom {
		return true
	}

	return false
}
