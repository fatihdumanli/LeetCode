package main

import "strings"
import "fmt"

func main() {
    dictionary := []string{"x", "b", "c"}

    r := replaceWords(dictionary, "bafdf fsfsd");
    fmt.Println(r);

}

// https://leetcode.com/problems/replace-words/
func replaceWords(dictionary []string, sentence string) string {

    var hashset = make(map[string]bool)

    for i := 0; i < len(dictionary); i++ {
        hashset[dictionary[i]] = true;
    }

    var ptr = 0;

    var sb strings.Builder

    var words = []string{}

    for ptr < len(sentence) {

        var char = sentence[ptr];
        if char == 32 {
            // we hit a wordbreak
            words = append(words, sb.String())
            sb.Reset();
            ptr++;
            continue;
        }

        sb.WriteByte(char);

        var current = sb.String()

        if _, ok := hashset[current]; ok {
            words = append(words, current);
            sb.Reset();

            for ptr < len(sentence) && sentence[ptr] != 32 {
                ptr++;
            }

            // if we hit the end of sentence, terminate
            if ptr == len(sentence) {
                break;
            }

            // otherwise it's an whitespace
            ptr++;
        } else {
            ptr++;
        }
    }

    if sb.Len() > 0 {
        words = append(words, sb.String());
    }

    sb.Reset()

    for i := 0; i < len(words); i++ {
        sb.WriteString(words[i]);

        if i < len(words) - 1 {
            sb.WriteString(" ");
        }
    }

    return sb.String();
}
