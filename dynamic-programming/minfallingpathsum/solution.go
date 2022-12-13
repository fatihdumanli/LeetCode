package main

import (
	"fmt"
	"math"
)

//https://leetcode.com/problems/minimum-falling-path-sum/
func main() {
	matrix := [][]int{{2,1,3},{6,5,4},{7,8,9}}
	r := minFallingPathSum(matrix)
	fmt.Println(r)
}

func minFallingPathSum(matrix [][]int) int {
	var n = len(matrix)
	var dp = make([][]int, n)

	for i := 0; i < len(dp); i++ {
		dp[i] = make([]int, n)
	}

	for i := 0; i < n; i++ {
		for j := 0; j < n; j++ {
			dp[i][j] = math.MaxInt32
		}
	}

	var fnReadDpResult = func(pos [2]int) int {
		if pos[0] < 0 || pos[0] >= n || pos[1] < 0 || pos[1] >= n {
			return math.MaxInt32
		}
		return dp[pos[0]][pos[1]]
	}

	var min = math.MaxInt32
	for j := 0; j < n; j++ {
		min = Min(min, helper(matrix, 0, j, &dp, n, fnReadDpResult))
	}


	return min
}

func helper(matrix [][]int, i, j int, dp *[][]int, n int, fnReadDpResult func(pos [2]int) int) int {

	// out of range
	if i < 0 || i >= n || j < 0 || j >= n {
		return math.MaxInt32
	}

	// last row
	if i == n - 1 {
		(*dp)[i][j] = matrix[i][j]
		return matrix[i][j]
	}

	var leftDiagonal = [2]int{i + 1, j - 1}
	var below = [2]int{i + 1, j}
	var rightDiagonal = [2]int{i + 1, j + 1}

	var min = math.MaxInt32

	var leftDiagonalResult = fnReadDpResult(leftDiagonal)

	if leftDiagonalResult == math.MaxInt32 {
		leftDiagonalResult = helper(matrix, leftDiagonal[0], leftDiagonal[1], dp, n, fnReadDpResult)
	}

	var rightDiagonalResult = fnReadDpResult(rightDiagonal)
	if rightDiagonalResult == math.MaxInt32 {
		rightDiagonalResult = helper(matrix, rightDiagonal[0], rightDiagonal[1], dp, n, fnReadDpResult)
	}

	var belowResult = fnReadDpResult(below)

	if belowResult == math.MaxInt32 {
		belowResult = helper(matrix, below[0], below[1], dp, n, fnReadDpResult)
	}

	min = Min(min, leftDiagonalResult)
	min = Min(min, rightDiagonalResult)
	min = Min(min, belowResult)

	(*dp)[i][j] = min + matrix[i][j]

	return (*dp)[i][j]
}

func Min(a, b int) int {
	if a < b {
		return a
	}
	return b
}