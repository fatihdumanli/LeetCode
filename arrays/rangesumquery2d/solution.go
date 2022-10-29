package main

import "fmt"

type NumMatrix struct {
	sumMatrix [][]int
}

func Constructor(matrix [][]int) NumMatrix {
	sm := make([][]int, len(matrix)+1)

	sm[0] = make([]int, len(matrix[0])+1)
	for i := 0; i < len(matrix); i++ {
		sm[i+1] = make([]int, len(matrix[i])+1)
		for j := 0; j < len(matrix[i]); j++ {
			sm[i+1][j+1] = sm[i][j+1] + sm[i+1][j] - sm[i][j] + matrix[i][j]
		}
	}

	return NumMatrix{sumMatrix: sm}
}

func (this *NumMatrix) SumRegion(row1 int, col1 int, row2 int, col2 int) int {
	return this.sumMatrix[row2+1][col2+1] - this.sumMatrix[row1+1-1][col2+1] - this.sumMatrix[row2+1][col1+1-1] + this.sumMatrix[row1+1-1][col1+1-1]
}

func main() {
	matrix := [][]int{{3, 0, 1, 4, 2}, {5, 6, 3, 2, 1}, {1, 2, 0, 1, 5}, {4, 1, 0, 1, 7}, {1, 0, 3, 0, 5}}

	numMatrix := Constructor(matrix)
	r := numMatrix.SumRegion(0, 0, 0, 0)
	fmt.Println(r)
}
