package main

import "fmt"

func main() {
    var s = "Mr John Smith          ";
    r := urlify(s, 13);
    fmt.Println(r);

    s = "aa bb cc dd                   ";
    r = urlify(s, 11);
    fmt.Println(r);

    s = "a b c d e f g                   ";
    r = urlify(s, 13);
    fmt.Println(r);
}

func urlify(s string, trueLength int) string {

    var charArr = []byte(s);

    // 1. Count the whitespaces
    var numOfWhiteSpaces = 0;

    for i := 0; i < trueLength; i++ {
        if s[i] == 32 {
            numOfWhiteSpaces++;
        }
    }

    var orgNumOfWhiteSpaces = numOfWhiteSpaces;

    // 2. Find the last non-whitespace character in the string
    var ptr = -1;
    for i := len(s) - 1; i >= 0; i-- {
        var ascii = int(s[i]);

        if ascii != 32 {
            ptr = i;
            break;
        }
    }

    var currentString = string(charArr);
    _ = currentString;

    for numOfWhiteSpaces > 0 {

        if charArr[ptr] == 32 {
            ptr--;
            numOfWhiteSpaces--;
            continue;
        }

        // How many whitespaces do I need to make space for?
        var shiftFactor = numOfWhiteSpaces * 2;

        charArr[ptr + shiftFactor] = charArr[ptr];
        charArr[ptr] = ' ';
        ptr--;
    }

    // 3. Calculate post-urlify length
    var postLength = trueLength + (orgNumOfWhiteSpaces * 2);

    // 3. Replace every whitespace with %20
    for i := 0; i < postLength; i++ {
        if charArr[i] == 32 {
            charArr[i] = '%';
            charArr[i + 1] = '2';
            charArr[i + 2] = '0';
        }
        currentString = string(charArr);
    }

    return string(charArr);
}
