package main

import (
	"dsa"
	"fmt"
	"time"

	"github.com/cheggaaa/pb"
	"github.com/pterm/pterm"
)

var words []string

func main() {

	words = loadFile("words.txt")

	var trie = dsa.NewTrie()

	bar := pb.StartNew(len(words))

	for _, w := range words {
		bar.Increment()
		trie.Insert(w)
	}
	bar.Finish()

	for {
		fmt.Println("\nSearch something...")
		var input string
		fmt.Scanln(&input)
		now := time.Now()
		//var results = getresults(input)
		var results = trie.Autocomplete(input)

		//for _, r := range results {
		//	fmt.Print(r)
		//}
		d := time.Since(now)
		str := pterm.Red(fmt.Sprintf("%d results found", len(results)))
		fmt.Println(str)
		fmt.Println(pterm.Cyan(fmt.Sprintf("It took %s", d)))
	}

	//if len(os.Args) > 1 {

	//	now := time.Now()
	//	var results = getresults(os.Args[1])

	//	//		for _, r := range results {
	//	//			fmt.Print(r)
	//	//		}
	//	str := pterm.Red(fmt.Sprintf("%d results found", len(results)))
	//	fmt.Println(str)
	//	d := time.Since(now)
	//	fmt.Println(pterm.Cyan(fmt.Sprintf("It took %s", d)))

	//	os.Exit(1)

	//}

}

func getresults(input string) []string {

	var results []string

outer:
	for _, w := range words {
		if len(w) < len(input) {
			continue
		}
		for i, c := range input {
			if w[i] != byte(c) {
				continue outer
			}
		}

		results = append(results, w)
	}
	return results

}
