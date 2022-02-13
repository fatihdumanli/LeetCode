package main

import "fmt"

func main() {

	var matrix [][]int
	matrix = make([][]int, 4)
	matrix[0] = make([]int, 4)
	matrix[1] = make([]int, 4)
	matrix[2] = make([]int, 4)
	matrix[3] = make([]int, 4)

	matrix[0] = []int{1, 2, 3, 4}
	matrix[1] = []int{5, 6, 7, 8}
	matrix[2] = []int{9, 10, 11, 12}
	matrix[3] = []int{13, 14, 15, 16}

	fmt.Println(matrix[0])
	fmt.Println(matrix[1])
	fmt.Println(matrix[2])
	fmt.Println(matrix[3])
	rotate(matrix)

	/*
		[1 2 3]
		[4 5 6]
		[7 8 9]
	*/
	fmt.Println(matrix[0])
	fmt.Println(matrix[1])
	fmt.Println(matrix[2])
	fmt.Println(matrix[3])
}

func rotate(matrix [][]int) {

	var n int = len(matrix)

	for layer := 0; layer < n/2; layer++ {
		first := layer
		last := n - 1 - layer
		for i := first; i < last; i++ {
			top := matrix[first][i]
			offset := i - first
			//left -> top
			matrix[first][i] = matrix[last-offset][first]
			//bottom -> left
			matrix[last-offset][first] = matrix[last][last-offset]
			//right -> bottom
			matrix[last][last-offset] = matrix[i][last]
			//top -> right
			matrix[i][last] = top

		}
	}
}
