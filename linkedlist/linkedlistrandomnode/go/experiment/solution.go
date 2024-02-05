package main

import (
    "fmt"
    "os"
    "net/http"
    "io/ioutil"
    "strconv"
    "math/rand"
)

func main() {
    items := pickRandom(readNumber, 50)

    for i := 0; i < len(items) - 1; i++ {
        for j := i + 1; j < len(items); j++ {
            if items[i] == items[j] {
                fmt.Println("There's a dupliate!!!")
            }
        }
    }

    fmt.Println(items)
}

func pickRandom(read func() (bool, int), k int) []int {

    var randomItems = make([]int, k)

    for i := 0; i < k; i++ {
        _, randomItems[i] = read()
    }

    var EOF = false
    var ptr = k

    for !EOF {
        end, v := read()

        rnd := rand.Intn(ptr)
        if rnd < k - 1 {
            if !end {
                randomItems[rnd] = v
            } else {
                EOF = true
            }
        }
        ptr++
    }

    return randomItems
}


// end?, val
func readNumber() (bool, int) {
    url := fmt.Sprintf("http://localhost:3333/pick")
    res, err := http.Get(url)
    if err != nil {
        os.Exit(1)
    }

    body, _ := ioutil.ReadAll(res.Body)

    num := fmt.Sprintf("%s", body)

    if num == "END" {
        return true, -100000000
    }

    i, _ := strconv.Atoi(num)
    return false, i
}


