package dsa

type Trie struct {
	val        byte
	children   *[]*Trie
	isNilNode  bool
	isRootNode bool
}

func NewTrie() Trie {
	var children = &[]*Trie{}
	return Trie{isRootNode: true, children: children}
}

//Inserts a new word to the trie
func (this *Trie) Insert(word string) {
	currentChar := word[0]
	currentNode := findChild(this, currentChar)

	if currentNode == nil {
		currentNode = addChild(this, currentChar)
	}

	for i := 1; i < len(word); i++ {
		nextChild := findChild(currentNode, word[i])
		if nextChild == nil {
			currentNode = addChild(currentNode, word[i])
		} else {
			currentNode = nextChild
		}
	}

	*currentNode.children = append(*currentNode.children, &Trie{isNilNode: true})
}

//Appends a new child to the given node
func addChild(n *Trie, v byte) *Trie {
	child := &Trie{val: v, children: &[]*Trie{}}
	*n.children = append(*n.children, child)
	return child
}

//Finds a children with the value of given parameter.
//Returns nil if child has not found.
func findChild(n *Trie, v byte) *Trie {
	for _, e := range *n.children {
		if e.val == v {
			return e
		}
	}
	return nil
}

//Returns true if the trie contains the given word
func (this *Trie) Search(word string) bool {
	var currentNode = this
	for i := 0; i < len(word); i++ {
		if currentNode == nil {
			return false
		}
		currentNode = findChild(currentNode, word[i])
	}
	if currentNode == nil {
		return false
	}
	for _, c := range *currentNode.children {
		if c.isNilNode {
			return true
		}
	}
	return false
}

//Returns true if trie contains a word with given prefix
func (this *Trie) StartsWith(prefix string) bool {
	var currentNode = this
	for i := 0; i < len(prefix); i++ {
		currentNode = findChild(currentNode, prefix[i])
		if currentNode == nil {
			return false
		}
	}
	return true
}

//Search all words that starts with given prefix
//Returns the list of matching words
func (this *Trie) Autocomplete(input string) []string {

	var results []string
	var currentNode = this
	for i := 0; i < len(input); i++ {
		currentNode = findChild(currentNode, input[i])
		if currentNode == nil {
			return results
		}
	}
	if currentNode == nil {
		return results
	}

	iterateChildren(currentNode, input[:len(input)-1], &results)
	return results
}

func iterateChildren(node *Trie, prefix string, r *[]string) {
	if node.isNilNode {
		*r = append(*r, prefix)
		return
	}
	var children = node.children
	if children == nil {
		return
	}
	prefix = prefix + string(node.val)
	for _, c := range *node.children {
		iterateChildren(c, prefix, r)
	}
}
