package main

import "fmt"

//https://leetcode.com/problems/design-add-and-search-words-data-structure/
func main() {

	var dict = Constructor()

	dict.AddWord("a")
	dict.AddWord("a")

	fmt.Println(dict.Search("a."))

}

/*
Input
["WordDictionary","addWord","addWord","addWord","search","search","search","search"]
[[],["bad"],["dad"],["mad"],["pad"],["bad"],[".ad"],["b.."]]


Output
[null,null,null,null,false,true,true,true]
*/

type Node struct {
	Val        int
	Children   *[27]*Node
	IsNilNode  bool
	IsRootNode bool
}

func NewNode(val rune) *Node {
	var children [27]*Node
	return &Node{
		Val:      int(val),
		Children: &children,
	}
}
func NewNilNode() *Node {
	return &Node{
		Children:  &[27]*Node{},
		IsNilNode: true,
	}
}

type WordDictionary struct {
	root *Node
}

func Constructor() WordDictionary {
	var rootNode = Node{IsRootNode: true, Children: &[27]*Node{}}
	return WordDictionary{root: &rootNode}
}

func (this *WordDictionary) AddWord(word string) {
	var ptr = this.root

	for _, r := range word {

		child := ptr.Children[r-'a']
		if child == nil {
			ptr.Children[r-'a'] = NewNode(r)
		}

		ptr = ptr.Children[r-'a']
	}

	ptr.Children[26] = NewNilNode()
}

func (this *WordDictionary) Search(word string) bool {
	return search(word, 0, this.root)
}

func search(word string, i int, n *Node) bool {

	//return true if the current node contains a nil child
	//otherwise, return false
	if i == len(word) {
		if n == nil || n.Children == nil {
			return false
		}
		return n.Children[26] != nil
	}

	var currentRune = word[i]

	if currentRune == byte('.') {
		for _, c := range *n.Children {

			if c == nil {
				continue
			}

			var r = search(word, i+1, c)

			//if one of the children returns true, skip the rest of the children
			if r {
				return true
			}
		}
	} else {

		var c = n.Children[currentRune-'a']
		if c == nil {
			return false
		}

		return search(word, i+1, c)
	}

	return false
}
