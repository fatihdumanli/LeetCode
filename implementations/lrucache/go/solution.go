package main

func main() {
	//["LRUCache","put","put","put","put","get","get","get","get","put","get","get","get","get","get"]
	//[[3],[1,1],[2,2],[3,3],[4,4],[4],[3],[2],[1],[5,5],[1],[2],[3],[4],[5]]

	var cache = Constructor(3)
	cache.Put(1,1)
	cache.Put(2,2)
	cache.Put(3,3)
	cache.Put(4,4)

	res := cache.Get(4)
	res = cache.Get(3)
	res = cache.Get(2)
	res = cache.Get(1)

	cache.Put(5,5)

	res = cache.Get(4)
	res = cache.Get(2)
	_ = res

}
