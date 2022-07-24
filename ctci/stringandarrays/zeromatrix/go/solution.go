package main

import "fmt"

func main() {

	var rows int = 3
	var cols int = 4
	var matrix [][]int
	matrix = make([][]int, rows)

	for i := 0; i < rows; i++ {
		matrix[i] = make([]int, cols)
	}

	matrix[0] = []int{0, 1, 2, 0}
	matrix[1] = []int{3, 4, 5, 2}
	matrix[2] = []int{1, 3, 1, 5}
	printMatrix(matrix)
	setZeroes(matrix)
	printMatrix(matrix)

}

func setZeroes(matrix [][]int) {

	var firstRowHasZero bool = false
	var firstColHasZero bool = false

	//check first row
	for i := 0; i < len(matrix[0]); i++ {
		if matrix[0][i] == 0 {
			firstRowHasZero = true
			break
		}
	}

	//check first col
	for i := 0; i < len(matrix); i++ {
		if matrix[i][0] == 0 {
			firstColHasZero = true
			break
		}
	}

	for i := 1; i < len(matrix); i++ {
		for j := 1; j < len(matrix[0]); j++ {
			if matrix[i][j] == 0 {
				matrix[i][0] = 0
				matrix[0][j] = 0
			}
		}
	}

	for i := 1; i < len(matrix); i++ {
		if matrix[i][0] == 0 {
			clearRow(matrix, i)
		}
	}

	for i := 1; i < len(matrix[0]); i++ {
		if matrix[0][i] == 0 {
			clearCol(matrix, i)
		}
	}

	printMatrix(matrix)

	//Clear first row
	if firstRowHasZero {
		clearRow(matrix, 0)
	}

	//clear first col
	if firstColHasZero {
		clearCol(matrix, 0)
	}

}

func clearRow(matrix [][]int, row int) {
	for i := 0; i < len(matrix[0]); i++ {
		matrix[row][i] = 0
	}
}

func clearCol(matrix [][]int, col int) {
	for i := 0; i < len(matrix); i++ {
		matrix[i][col] = 0
	}
}

func printMatrix(matrix [][]int) {
	var m int = len(matrix)
	var n int = len(matrix[0])

	for i := 0; i < m; i++ {
		for j := 0; j < n; j++ {
			fmt.Printf("%d ", matrix[i][j])
		}
		fmt.Println()
	}
}
