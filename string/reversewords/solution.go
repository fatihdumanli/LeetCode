package main

import (
	"fmt"
	"strings"
)

func main() {
	s := "   the  sky   is blue  "
	s = "the sky is blue"
	//s := "sebo"
	r := reverseWords(s)
	fmt.Println(r)
}

type listNode struct {
	val string
	next *listNode
}

func reverseWords(s string) string {
	var head *listNode = &listNode{}

	var listPtr = head
	var ptr = 0

	var sb strings.Builder
	var buffer strings.Builder

	for ptr < len(s) {
	    for ptr < len(s) && s[ptr] == ' ' {
			if buffer.Len() > 0 {
				listPtr.next = &listNode{val: buffer.String()}
				listPtr = listPtr.next
				buffer.Reset()
			}
	    	ptr++
	    }

		if ptr >= len(s) {
			continue
		}

		buffer.WriteByte(s[ptr])
		ptr++
	}

	if buffer.Len() > 0 {
		listPtr.next = &listNode{val: buffer.String()}
	}

	reverseList(head.next, &sb)

	var n = sb.Len()
	return sb.String()[:n-1]
}

func reverseList(head *listNode, sb *strings.Builder) {
	if head.next == nil {
		sb.WriteString(head.val)
		sb.WriteString(" ")
		return
	}

	reverseList(head.next, sb)

	sb.WriteString(head.val)
	sb.WriteString(" ")

	head.next.next = head
	head.next = nil
}
