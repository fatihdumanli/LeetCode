package main

import "fmt"

func main() {
	image := [][]int{{1, 1, 1}, {1, 1, 0}, {1, 0, 1}}

	r := floodFill(image, 1, 1, 2)

	fmt.Println(r)
}

/*

	1  1  1
	1  1  0
	1  0  1

*/
func floodFill(image [][]int, sr int, sc int, color int) [][]int {

	if image[sr][sc] == color {
		return image
	}

	var startingColor = image[sr][sc]
	dfs(image, startingColor, sr, sc, color)

	return image
}

func dfs(image [][]int, startingColor int, row int, col int, color int) {
	if row < 0 || row >= len(image) {
		return
	}

	if col < 0 || col >= len(image[row]) {
		return
	}

	if image[row][col] != startingColor {
		return
	}

	image[row][col] = color

	dfs(image, startingColor, row, col-1, color)
	dfs(image, startingColor, row-1, col, color)
	dfs(image, startingColor, row, col+1, color)
	dfs(image, startingColor, row+1, col, color)
}
