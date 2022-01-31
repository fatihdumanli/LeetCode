package main

import (
	"fmt"
	"strings"
	"time"
	"unsafe"

	"github.com/tjarratt/babble"
)

func intp(x int) *int {
	return &x
}

type StringBuilder struct {
	runes  []byte
	length *int
}

func NewStringBuilder() StringBuilder {
	runes := make([]byte, 500)
	return StringBuilder{runes, intp(0)}
}

func (s *StringBuilder) Append(str string) {

	if *s.length+len(str) >= len(s.runes) {
		s.resize()
	}

	ptr := *s.length

	for i := 0; i < len(str); i++ {
		s.runes[ptr] = str[i]
		ptr++
		*s.length++
	}
}

//mutates
func (s *StringBuilder) resize() {
	l := len(s.runes)
	newRunes := make([]byte, 2*l)

	for i := 0; i < l; i++ {
		newRunes[i] = s.runes[i]
	}

	s.runes = newRunes
}

func (s StringBuilder) String() string {
	return *(*string)(unsafe.Pointer(&s.runes))
	//return string(s.runes)
}

func main() {

	//1.3s to concat 20_000 words
	n := 5
	now := time.Now()
	d := time.Since(now)

	words := []string{}
	babbler := babble.NewBabbler()

	for i := 0; i < n; i++ {
		word := babbler.Babble()
		words = append(words, word)
	}

	now = time.Now()
	res2 := concatWordsWithCustomSb(words)
	//concatWordsWithCustomSb(words)
	d = time.Since(now)
	fmt.Printf("it took %s\n", d)
	fmt.Println(res2)
	_ = res2

	now = time.Now()
	res1 := concatWordsWithBuiltinSb(words)
	//concatWordsWithBuiltinSb(words)
	d = time.Since(now)
	fmt.Printf("it took %s\n", d)
	fmt.Println(res1)
	_ = res1

}

func concatWordsWithBuiltinSb(words []string) string {
	var sb strings.Builder
	for _, w := range words {
		sb.WriteString(w)
	}
	return sb.String()
}

func concatWordsWithCustomSb(words []string) string {

	var sb = NewStringBuilder()
	for _, w := range words {
		sb.Append(w)
	}
	return sb.String()
}
