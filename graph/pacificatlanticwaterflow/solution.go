package main

import "fmt"

//https://leetcode.com/problems/pacific-atlantic-water-flow/
func main() {
	var heights [][]int = make([][]int, 5)
	heights[0] = make([]int, 5)
	heights[1] = make([]int, 5)
	heights[2] = make([]int, 5)
	heights[3] = make([]int, 5)
	heights[4] = make([]int, 5)

	heights[0] = []int{1, 2, 2, 3, 5}
	heights[1] = []int{3, 2, 3, 4, 4}
	heights[2] = []int{2, 4, 5, 3, 1}
	heights[3] = []int{6, 7, 1, 4, 5}
	heights[4] = []int{5, 1, 1, 2, 4}

	fmt.Println(pacificAtlantic(heights))

}

const PasificHeight int = -1
const AtlanticHeight int = -2

type Partition struct {
	Row       int
	Col       int
	Height    int
	Neighbors []*Partition
	IsOcean   bool
}

func (p *Partition) AddNeighbor(n *Partition) {
	p.Neighbors = append(p.Neighbors, n)
}

func Pacific() *Partition {
	return &Partition{
		Height:  PasificHeight,
		IsOcean: true,
	}
}

func Atlantic() *Partition {
	return &Partition{
		Height:  AtlanticHeight,
		IsOcean: true,
	}
}

func pacificAtlantic(heights [][]int) [][]int {

	var width = len(heights[0])

	var partitions []Partition = make([]Partition, len(heights)*width)

	for row := 0; row < len(heights); row++ {
		for col := 0; col < len(heights[row]); col++ {
			partitions[(row*width)+col] = Partition{Row: row, Col: col, Height: heights[row][col], Neighbors: []*Partition{}}
		}
	}

	for i := 0; i < len(heights); i++ {
		for j := 0; j < len(heights[i]); j++ {
			//link oceans
			linkOceans(i, j, len(heights), width, &partitions)
			//link neighbors
			linkNeighbors(i, j, heights, &partitions)

		}
	}

	var visited = make(map[int]int, 4)
	var oceans = make(map[int]bool, 0)
	var result [][]int

	for _, p := range partitions {

		dfs(&p, width, visited, oceans)

		if len(oceans) == 2 {
			result = append(result, []int{p.Row, p.Col})
		}

		oceans = make(map[int]bool, 0)
		visited = make(map[int]int, 4)
	}

	return result
}
func dfs(p *Partition, w int, visited map[int]int, oceans map[int]bool) {

	if p.IsOcean {
		_, ok := oceans[p.Height]
		if !ok {
			oceans[p.Height] = true
		}
		return
	}

	var idx = (p.Row * w) + p.Col
	visited[idx] = 1

	for _, n := range p.Neighbors {

		//visit only the neighbor's height is less than the current cell
		var nIndex = (n.Row * w) + n.Col
		if (visited[nIndex] == 0 && n.Height <= p.Height) || n.IsOcean {
			dfs(n, w, visited, oceans)
		}

	}

	visited[idx] = 2
}

func linkOceans(i, j, h, w int, partitions *[]Partition) {
	var idx = (i * w) + j
	//top - link to pacific
	if i == 0 {
		(*partitions)[idx].AddNeighbor(Pacific())
	}
	//left - link to pacific (beware of duplicates)
	if j == 0 {
		(*partitions)[idx].AddNeighbor(Pacific())
	}
	//bottom - link to atlantic
	if i == h-1 {
		(*partitions)[idx].AddNeighbor(Atlantic())
	}
	//right - link to atlantic
	if j == w-1 {
		(*partitions)[idx].AddNeighbor(Atlantic())
	}

}

func linkNeighbors(i, j int, heights [][]int, partitions *[]Partition) {
	var w = len(heights[i])
	var h = len(heights)
	var idx = (i * w) + j

	//link right
	if j < w-1 {
		var rIndex = (i * w) + j + 1
		(*partitions)[idx].AddNeighbor(&(*partitions)[rIndex])
	}

	//link to bottom
	if i < h-1 {
		var bIndex = ((i + 1) * w) + j
		(*partitions)[idx].AddNeighbor(&(*partitions)[bIndex])
	}

	//link to left
	if j > 0 {
		var lIndex = (i * w) + j - 1
		(*partitions)[idx].AddNeighbor(&(*partitions)[lIndex])
	}

	//link to top
	if i > 0 {
		var tIndex = ((i - 1) * w) + j
		(*partitions)[idx].AddNeighbor(&(*partitions)[tIndex])
	}

}
