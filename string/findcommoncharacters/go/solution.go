package main

import "fmt"
import "math"

func main() {
    words := []string{"bella", "label", "roller"}
    r := commonChars(words);
    fmt.Println(r);
}

func commonChars(words []string) []string {

    var result = []string{}
    var matrix = [][26]int{}

    for i := 0; i < len(words); i++ {
        matrix = append(matrix, [26]int{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0});

        for k := 0; k < len(words[i]); k++ {
            var char = words[i][k];
            var ascii = int(char);
            var idx = ascii - 97;

            matrix[i][idx]++;
        }
    }

    // Go through the letters
    for i := 0; i < 26; i++ {

        var minOccurence = math.MaxInt32;
        var currentCharInString = string(byte(i + 97))

        for k := 0; k < len(matrix); k++ {

            // if it's 0 for any of the words, we skip it 
            if matrix[k][i] == 0 {
                minOccurence = math.MaxInt32;
                break;
            }

            var occurence = matrix[k][i];
            minOccurence = Min(minOccurence, occurence);

        }

        if minOccurence != math.MaxInt32 {
            for i := 0; i < minOccurence; i++ {
                result = append(result, currentCharInString);
            }
        }
    }

    return result;
}

func Min(a, b int) int {
    if a <= b {
        return a;
    }
    return b;
}
