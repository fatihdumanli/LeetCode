package main

import (
	"io"
	"net/http"
        "fmt"
        "math/rand"
        "time"
)

var arr []int
var ptr = 0
var size = 50

func main() {
    arr = generateRandomArray(size)

    http.HandleFunc("/pick", pickNumber)

    fmt.Println("Started HTTP server on port 3333")
    err := http.ListenAndServe(":3333", nil)
    
    if err != nil {
        fmt.Println(err)
    }
}

func pickNumber(w http.ResponseWriter, r *http.Request) {
    if ptr == size {
        // End of stream
        io.WriteString(w, "END")
        fmt.Println("End of the stream")
        return
    }

    io.WriteString(w, fmt.Sprint(arr[ptr]))
    ptr++
}

func generateRandomArray(size int) []int {
    rand.Seed(time.Now().UnixNano())

    arr := make([]int, size)

    for i := 0; i < size; i++ {
        var n int
        var contains = true

        for contains {
            n = rand.Intn(100)
            contains = doesContain(arr, n)
        }

        arr[i] = n
    }

    return arr
}

func doesContain(arr []int, val int) bool {
    for i := 0; i < len(arr); i++ {
        if arr[i] == val {
            return true
        }
    }
    return false
}
