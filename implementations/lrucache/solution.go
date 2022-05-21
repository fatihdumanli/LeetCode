package main

import "fmt"

func main() {

	/*


		["LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"]
		[[2], [1, 1], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4]]

		["LRUCache","get","put","get","put","put","get","get"]
		[[2],[2],[2,6],[1],[1,5],[1,2],[1],[2]]


		get(2)
		put(2,6)
		get(1)
		put(1,5)
		put(1,2)
		get(1)
		get(2)
	*/
	var cache = Constructor(2)
	cache.Get(2)
	cache.Put(2, 6)
	cache.Get(1)
	cache.Put(1, 5)
	cache.Put(1, 2)
	cache.Get(1)

	res := cache.Get(2)
	fmt.Println(res)
}
