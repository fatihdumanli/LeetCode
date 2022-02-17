package main

import "fmt"

func main() {

	var preq [][]int

	preq = append(preq, []int{1, 0})
	fmt.Println(canFinish(2, preq))
}

func canFinish(numCourses int, prerequisites [][]int) bool {

	var adjList map[int][]int = make(map[int][]int, numCourses)
	// [1,0], [1,2], [0,4], [2,3]
	for _, p := range prerequisites {
		adjList[p[0]] = append(adjList[p[0]], p[1])
	}
	var visited map[int]int = make(map[int]int, numCourses)

	for i := 0; i < numCourses; i++ {
		if !dfs(i, adjList, visited) {
			return false
		}
	}

	return true
}

func dfs(node int, adjList map[int][]int, visited map[int]int) bool {

	var neighbors = adjList[node]

	visited[node] = 1
	for _, n := range neighbors {
		if visited[n] == 1 {
			return false
		}
		if visited[n] == 0 {
			if !dfs(n, adjList, visited) {
				return false
			}
		}
	}
	visited[node] = 2

	return true
}
