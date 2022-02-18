package main

import "fmt"

func main() {

	var matrix [][]byte = make([][]byte, 4)
	matrix[0] = []byte{'1', '1', '0', '0', '0'}
	matrix[1] = []byte{'1', '1', '0', '0', '0'}
	matrix[2] = []byte{'0', '0', '1', '0', '0'}
	matrix[3] = []byte{'0', '0', '0', '1', '1'}

	fmt.Println(numIslands(matrix))
}

func numIslands(grid [][]byte) int {

	var n = 0

	for i := 0; i < len(grid); i++ {
		for j := 0; j < len(grid[i]); j++ {
			if grid[i][j] == '1' {
				dfs(i, j, grid)
				n = n + 1
			}
		}
	}

	return n
}

func dfs(i, j int, grid [][]byte) {

	if i < 0 || j < 0 || i > len(grid)-1 || j > len(grid[i])-1 {
		return
	}
	//don't touch the water and processed land
	if grid[i][j] == '0' || grid[i][j] == '2' {
		return
	}

	//processed land
	grid[i][j] = '2'

	//visit right, bottom, left and top
	dfs(i, j+1, grid)
	dfs(i+1, j, grid)
	dfs(i, j-1, grid)
	dfs(i-1, j, grid)
}
