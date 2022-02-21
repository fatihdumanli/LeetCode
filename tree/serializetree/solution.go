package main

import (
	"dsa"
	"strconv"
	"strings"
)

type TreeNode = dsa.TreeNode
type Codec struct{}

func Constructor() Codec {
	return Codec{}
}

func traverse(root *TreeNode, arr *[]int64) {
	if root == nil {
		return
	}

	//first 12 bit for the value
	var num int64 = int64(root.Val)

	//if the number is negative, we're going to set the msb to '1!
	if num < 0 {
		//make 11th bit '1'
		var one int64 = 1
		one <<= 11
		num |= one
	}

	//bits 12-23 for the left child
	if root.Left != nil {
		var leftVal = int64(root.Left.Val)
		leftVal <<= 12
		//TODO check negatvies
		num |= leftVal
	} else {
		//need a mask
		//1111 1111 1111
		var one int64 = 1
		one <<= 12
		one -= 1
		one <<= 12

		num |= one
	}

	//			       		RIGHT	   |	LEFT	  |     VAL
	//0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0010 0000 0000 0001
	if root.Right != nil {
		var rightVal = int64(root.Right.Val)
		rightVal = rightVal << 24
		num |= rightVal
	} else {
		var one int64 = 1
		one <<= 24
		one -= 1
		one <<= 24
		num |= one
	}

	*arr = append(*arr, num)
	traverse(root.Left, arr)
	traverse(root.Right, arr)

}

func (this *Codec) serialize(root *TreeNode) string {
	var arr []int64
	traverse(root, &arr)
	return serializeArr(arr)
}
func (this *Codec) deserialize(data string) *TreeNode {
	var arr []int64 = deserializeArr(data)

	var root *TreeNode

	var doesHaveLeftChild bool
	var doesHaveRightChild bool

	for _, v := range arr {
		if root == nil {
			//the first 12 bits forms the actual value
			var left = getBinaryRepresentation(v, 12, 24)
			var right = getBinaryRepresentation(v, 24, 36)

			//1111 1111 -> reserved for 'NONE'
			if areBinariesEqual(left, "111111") {
				doesHaveLeftChild = false
			} else {
				doesHaveLeftChild = true
			}

			if areBinariesEqual(right, "111111") {
				doesHaveLeftChild = false
			} else {
				doesHaveLeftChild = true
			}

			var one int64 = 1
			one <<= 12
			one -= 1

			v &= one
			root = &TreeNode{Val: int(v)}

			continue
		}

		if doesHaveLeftChild {
		}

		if doesHaveRightChild {
		}

	}

	return nil
}

func getBinaryRepresentation(num int64, from, end int) string {
	return ""
}

func areBinariesEqual(b1, b2 string) bool {
	return false
}

func main() {
	var root = &TreeNode{Val: 1}
	root.AddLeftChild(2)
	root.AddRightChild(3)
	//	root.Right.AddLeftChild(4)
	//	root.Right.AddRightChild(5)

	c := Constructor()
	data := c.serialize(root)
	tree := c.deserialize(data)

	_ = tree
}

func serializeArr(arr []int64) string {
	var result string

	for _, v := range arr {
		result += strconv.FormatInt(v, 10)
		result += ","
	}
	return result
}

func deserializeArr(data string) []int64 {
	var arr []int64
	var parts = strings.Split(data, ",")
	for _, p := range parts {
		var converted, err = strconv.Atoi(p)
		if err == nil {
			arr = append(arr, int64(converted))
		}
	}
	return arr
}
