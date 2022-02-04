package main

import (
	"bufio"
	"os"
)

func loadFile(p string) []string {
	var err error
	f, err := os.Open(p)
	if err != nil {
		panic(err)
	}
	defer f.Close()

	r := bufio.NewReader(f)

	var words []string
	var line string

	for err == nil {
		line, err = r.ReadString(byte('\n'))
		words = append(words, line)
	}

	return words
}
