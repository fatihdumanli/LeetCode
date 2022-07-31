package main

import "fmt"

func main() {
	candies := 7
	num_people := 4
	r := distributeCandies(candies, num_people)
	fmt.Println(r)
}

func distributeCandies(candies int, num_people int) []int {
	var result []int = make([]int, num_people)

	var who = 0;
	var howMany = 1;
	for candies > 0 {
		if candies < howMany {
			result[who] += candies
			break
		} else {
			result[who] += howMany
			candies -= howMany
		}

		howMany++
		who = (who + 1) % num_people
	}

	return result
}