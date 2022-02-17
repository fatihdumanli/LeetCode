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
	Children   *[]*Node
	IsNilNode  bool
	IsRootNode bool
}

func NewNode(val rune) *Node {
	var children []*Node
	return &Node{
		Val:      int(val),
		Children: &children,
	}
}
func NewNilNode() *Node {
	return &Node{
		Children:  &[]*Node{},
		IsNilNode: true,
	}
}

func (n *Node) appendChild(val rune) *Node {
	var newChild = NewNode(val)
	*n.Children = append(*n.Children, newChild)
	return newChild
}

func (n *Node) appendNilChild() {
	var newChild = NewNilNode()
	*n.Children = append(*n.Children, newChild)
}

func (n *Node) containsNilChild() bool {

	if n.IsNilNode {
		return false
	}

	for _, c := range *n.Children {
		if c.IsNilNode {
			return true
		}
	}
	return false
}

func (n *Node) getChild(val rune) *Node {

	for _, c := range *n.Children {
		if c.Val == int(val) {
			return c
		}
	}

	return nil
}

type WordDictionary struct {
	root *Node
}

func Constructor() WordDictionary {
	var rootNode = Node{IsRootNode: true, Children: &[]*Node{}}
	return WordDictionary{root: &rootNode}
}

func (this *WordDictionary) AddWord(word string) {
	var ptr = this.root

	for _, r := range word {
		child := ptr.getChild(r)
		if child == nil {
			child = ptr.appendChild(r)
			ptr = child
		} else {
			ptr = child
		}
	}
	ptr.appendNilChild()
}

func (this *WordDictionary) Search(word string) bool {
	return search(word, 0, this.root)
}

func search(word string, i int, n *Node) bool {

	//return true if the current node contains a nil child
	//otherwise, return false
	if i == len(word) {
		return n.containsNilChild()
	}

	var currentRune = word[i]

	if currentRune == byte('.') {
		for _, c := range *n.Children {
			var r = search(word, i+1, c)

			//if one of the children returns true, skip the rest of the children
			if r {
				return true
			}
		}
	} else {

		var c = n.getChild(rune(currentRune))
		if c == nil {
			return false
		}

		return search(word, i+1, c)
	}

	return false
}
