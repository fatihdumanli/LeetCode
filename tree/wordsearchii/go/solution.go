package main

import "fmt"

//https://leetcode.com/problems/word-search-ii/submissions/
func main() {

	board := [][]byte{
		{'o', 'a', 'b', 'n'},
		{'o', 't', 'a', 'e'},
		{'a', 'h', 'k', 'r'},
		{'a', 'f', 'l', 'v'},
	}

	words := []string{"oa", "oaa"}
	fmt.Println(findWords(board, words))
}

//we don't keep the value in the node.
//if the node is the last letter of any word, the field 'word' is set to the word instead of an empty string
//so that we can get rid of string concat or stringbuilder
type trieNode struct {
	word     string
	children *[26]*trieNode
}

func NewTrieNode() *trieNode {
	return &trieNode{
		children: &[26]*trieNode{},
	}
}

func buildTrie(words []string) *trieNode {

	root := &trieNode{children: &[26]*trieNode{}}

	for _, w := range words {
		ptr := root
		for _, c := range w {
			var idx = c - 97
			if ptr.children[idx] == nil {
				ptr.children[idx] = NewTrieNode()
			}
			ptr = ptr.children[idx]
		}
		ptr.word = w
	}

	return root
}

func findWords(board [][]byte, words []string) []string {

	//building trie
	root := buildTrie(words)

	var hashset map[string]bool = make(map[string]bool)
	for i := 0; i < len(board); i++ {
		for j := 0; j < len(board[0]); j++ {
			dfs(board, i, j, root, hashset)
		}
	}

	var result []string = make([]string, len(hashset))
	i := 0
	for k := range hashset {
		result[i] = k
		i++
	}

	return result
}

func dfs(board [][]byte, i, j int, currentNode *trieNode, hashset map[string]bool) {

	//outta boundaries
	if i < 0 || j < 0 || i > len(board)-1 || j > len(board[i])-1 {
		return
	}
	//visited
	if board[i][j] == 0 {
		return
	}

	var idx = board[i][j] - 97
	child := currentNode.children[idx]
	if child == nil {
		return
	}

	currentNode = child
	if currentNode.word != "" {
		if !hashset[currentNode.word] {
			hashset[currentNode.word] = true
		}
	}

	temp := board[i][j]
	//visit
	board[i][j] = 0

	dfs(board, i-1, j, currentNode, hashset)
	dfs(board, i+1, j, currentNode, hashset)
	dfs(board, i, j-1, currentNode, hashset)
	dfs(board, i, j+1, currentNode, hashset)

	board[i][j] = temp

}
