package main

import "fmt"

//https://leetcode.com/problems/online-stock-span/
//monotonic stack
type pair struct {
	first  int
	second int
}

type StockSpanner struct {
	stack []pair
	nums  []int
}

func (s *StockSpanner) pop() pair {
	var n = len(s.stack) - 1
	var elm = s.stack[n]
	s.stack = s.stack[:n]
	return elm
}

func (s *StockSpanner) top() pair {
	var n = len(s.stack) - 1
	return s.stack[n]
}

func Constructor() StockSpanner {
	return StockSpanner{}
}

func (this *StockSpanner) Next(price int) int {

	var cnt = 0
	for len(this.stack) > 0 && price >= this.top().first {
		cnt += this.top().second
		this.pop()
	}
	cnt++
	this.stack = append(this.stack, pair{first: price, second: cnt})

	return cnt
}

func main() {
	ss := Constructor()

	ss.Next(60)
	ss.Next(75)
	ss.Next(50)
	ss.Next(90)
	ss.Next(95)
	ss.Next(100)
	r := ss.Next(85)
	r = ss.Next(90)
	fmt.Println(r)
}
