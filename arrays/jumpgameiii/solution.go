package main

import "fmt"

func main() {
	arr := []int{3, 0, 2, 1, 2}
	r := canReach(arr, 2)
	fmt.Println(r)
}

func canReach(arr []int, start int) bool {
	var visited = make([]bool, len(arr))
	return helper(arr, start, visited)
}

func helper(arr []int, start int, visited []bool) bool {

	if arr[start] == 0 {
		return true
	}

	visited[start] = true

	b := start - arr[start]
	f := start + arr[start]

	var backward = false
	var forward = false

	if b >= 0 && !visited[b] {
		backward = helper(arr, b, visited)
	}

	if f <= len(arr)-1 && !visited[f] {
		forward = helper(arr, f, visited)
	}

	return backward || forward
}
