package main

import "fmt"

func main() {
	var matrix [][]int = make([][]int, 3)

	//matrix[0] = make([]int, 4)
	//matrix[1] = make([]int, 4)
	//matrix[2] = make([]int, 4)

	//matrix[0] = []int{1, 2, 3, 4}
	//matrix[1] = []int{5, 6, 7, 8}
	//matrix[2] = []int{9, 10, 11, 12}

	//matrix[0] = make([]int, 3)
	//matrix[1] = make([]int, 3)
	//matrix[2] = make([]int, 3)

	matrix[0] = []int{1, 2, 3}
	matrix[1] = []int{4, 5, 6}
	matrix[2] = []int{7, 8, 9}
	res := spiralOrder(matrix)
	fmt.Println(res)
}

func spiralOrder(matrix [][]int) []int {

	//0 -> left
	//1 -> bottom
	//2 -> left
	//3 -> right
	var result = make([]int, len(matrix)*len(matrix[0]))
	var ptr = 0

	var row, col = 0, 0

	for {

		//right
		for {
			result[ptr] = matrix[row][col]
			matrix[row][col] = 200 //visited
			ptr++

			//check the boundary
			col++
			if col > len(matrix[0])-1 || matrix[row][col] == 200 {
				col--
				row++
				break
			}
		}

		if ptr >= len(result) {
			return result
		}

		//bottom
		for {
			result[ptr] = matrix[row][col]
			matrix[row][col] = 200 //visisted
			ptr++

			row++
			if row > len(matrix)-1 || matrix[row][col] == 200 {
				row--
				col--
				break
			}
		}

		if ptr >= len(result) {
			return result
		}
		//left
		for {
			result[ptr] = matrix[row][col]
			matrix[row][col] = 200 //visisted
			ptr++

			col--
			if col < 0 || matrix[row][col] == 200 {
				col++
				row--
				break
			}
		}

		if ptr >= len(result) {
			return result
		}
		//up
		for {
			result[ptr] = matrix[row][col]
			matrix[row][col] = 200 //visisted
			ptr++

			row--
			if row < 0 || matrix[row][col] == 200 {
				row++
				col++
				break
			}
		}
		if ptr >= len(result) {
			return result
		}

	}

}
