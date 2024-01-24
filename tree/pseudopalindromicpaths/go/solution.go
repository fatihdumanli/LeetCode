package main

import (
	"fmt"
	"strconv"
)

type TreeNode struct {
	Val   int
	Left  *TreeNode
	Right *TreeNode
}

func main() {
	var new = 1 << 2
	binary := strconv.FormatInt(int64(new), 2)
	fmt.Println(binary)

	p := &TreeNode{Val: 2}
	p.Left = &TreeNode{Val: 3}
	p.Left.Left = &TreeNode{Val: 3}
	p.Left.Right = &TreeNode{Val: 1}
	p.Right = &TreeNode{Val: 1}
	p.Right.Right = &TreeNode{Val: 1}

	r := pseudoPalindromicPaths(p)
	fmt.Println(r)
}

// https://leetcode.com/problems/pseudo-palindromic-paths-in-a-binary-tree/
func pseudoPalindromicPaths(root *TreeNode) int {

	var freq int
	var answer int = 0

	val := intp(answer)

	helper(root, freq, val)

	return *val
}

/* 
    The conditions for a string to be a palindrome is that the number of odd occurences cannot exceed 1.

    racecar (r:2, a:2, c: 2, e: 1)
    daad (d: 2, a: 2)
    demed (d: 2, e: 2, m: 1)
    demad (d: 2: e: 1, m: 1, a: 1) NOT A PALINDROME

    So, if we obtain a frequency array for every path from root the leaf
    We should be able to evaluate the path in order to understand if it's a pseudo-palindromic path.

    We're going to store the frequency in an integer as bits. 
    Imagine 0 0 0 0 0 0 0 0 0 0
    The sequence 1,2,3
    Would end up with
    1 1 1 0 0 0 0 0 0 0

    So how do we know about number of occurences?

    We're going to get help from XOR (^) operator.

    0 ^ 0 = 0
    0 ^ 1 = 1
    1 ^ 0 = 1
    1 ^ 1 = 0

    Imagine having a 1,2 for once. (Currently does not constitute a pseudo-palindrome.)

    1 1 0 0 0 0 0 0 0 0

    Imagine we have a new 2. (1 << (10 - 2)) (Total 2)

    0 1 0 0 0 0 0 0 0 0

    If we apply XOR to these two numbers.

        0 1 1 0 0 0 0 0 0 0 0
        0 0 1 0 0 0 0 0 0 0 0
    ^-------------------------

        0 1 0 0 0 0 0 0 0 0 0

   We can see that the digit for responsible for holding the appearnce of '2' is now 0.

   If we apply XOR again. - Imagine '2' appeared once more. (Total 3)

        0 1 0 0 0 0 0 0 0 0 0
        0 0 1 0 0 0 0 0 0 0 0
    ^-------------------------
        0 1 1 0 0 0 0 0 0 0 0

    Now, from the experiment above. We can see that the corresponding digit becomes 0
    everytime the occurences become even, and it becomes 1 when it becomes odd.

    So now we have an integer in which the 'evenness' of occurences are represented.

    '0 1 1 0 0 0 0 0 0 0 0'

    Step 2:

    If we subtract '1' from any binary number, it will make all right handside bits '1'.

    num       |   00001   00010  000100  01000  10000 100000 
    num - 1   |   00000   00001  000011  00111  01111 011111

    See, it convert's all right '0's into '1's.

    If there's only 1 number in the original number, after applying AND operator,
    The result will always be 0.

    num       |   00001   00010  000100  01000  10000 100000 
    num - 1   |   00000   00001  000011  00111  01111 011111

    &             00000   00000  000000  00000  00000 000000


    However, let's experiment a number where there's more than one odd occurence.


    000000101000
    000000000001
  - ------------
    000000100111


    Now we AND the original number with subtraction result.

    000000101000
  & 000000100111
----------------
    000000100000

    From the two experiment above, if (num) & (num - 1) == 0. There's only one 
    odd occurence in the current path, so we increment the answer by one if we
    hit such a case.
---------


*/ 
func helper(root *TreeNode, freq int, answer *int) {
	if root == nil {
		return
	}

	if root.Left == nil && root.Right == nil {
		freq ^= 1 << (10 - (root.Val))

		binary := strconv.FormatInt(int64(freq), 2)
		fmt.Println(binary)

		if freq&(freq-1) == 0 {
			*answer++
		}

		return
	}
	freq ^= 1 << (10 - root.Val)
	binary := strconv.FormatInt(int64(freq), 2)
	fmt.Println(binary)

	helper(root.Left, freq, answer)
	helper(root.Right, freq, answer)
}

func intp(x int) *int {
	return &x
}
