package main

import (
	"fmt"
)

//https://leetcode.com/problems/most-stones-removed-with-same-row-or-column/
func main() {
	//stones := [][]int{{0, 1}, {1, 2}, {1, 3}, {3, 3}, {2, 3}, {0, 2}}
	//stones := [][]int{{3,2},{3,1},{4,4},{1,1},{0,2},{4,0}}
	//stones := [][]int{{0,1},{0,2},{4,3},{2,4},{0,3}}
	//stones := [][]int{{0,0},{0,2},{1,1},{2,0},{2,2}}
	//stones := [][]int{{0,0},{0,1},{1,0},{1,2},{2,1},{2,2}}
        //stones := [][]int{{3,3},{4,4},{1,4},{1,5},{2,3},{4,3},{2,4}}
        stones := [][]int{{0,1},{1,0}}
	r := removeStones(stones)
	fmt.Println(r)
}

func removeStones(stones [][]int) int {
        var encodeCell = func(i, j, w int) int {
                return (i * w) + j
        }

        var maxRow int
        var maxCol int
        var stonesByRow map[int][]int = make(map[int][]int)
        var stonesByCol map[int][]int = make(map[int][]int)

        for i := 0; i < len(stones); i++ {
                maxRow = Max(maxRow, stones[i][0])
                maxCol = Max(maxCol, stones[i][1])
        }

        for i := 0; i < len(stones); i++ {
                r := stones[i][0]
                c := stones[i][1]

                encoded := encodeCell(r, c, maxCol + 1)

                stonesByRow[r] = append(stonesByRow[r], encoded)
                stonesByCol[c] = append(stonesByCol[c], encoded)
        }



        //cannot allocate 769917760-byte block (3899392 in use)
        //var groups []*int = make([]*int, encodeCell(maxRow, maxCol + 1, maxCol + 1))
        //the map groups will hold the encoded cell -> the output of encodeCell function above, as the key
        var groups map[int]*int = make(map[int]*int)

        for i := 0; i < len(stones); i++ {
             var r = stones[i][0]
             var c = stones[i][1]

             encoded := encodeCell(r, c, maxCol + 1)

             if groups[encoded] == nil {
                dfs(r, c, maxCol + 1, encoded, stonesByRow, stonesByCol, groups)
             }
        }

        var hashmap map[int]int = make(map[int]int)
        for _, v := range groups {
               if _, ok := hashmap[*v]; ok {
                       hashmap[*v]++
               } else {
                       hashmap[*v] = 1
               }
        }

        var answer int = 0
        for _, v := range hashmap {
                answer += v - 1
        }

        return answer
}


//dfs function will change the group of peers of matrix[row][col]. it will set their group to 'groupName'
func dfs(row int, col int, maxCol int, groupName int, stonesByRow map[int][]int, stonesByCol map[int][]int, groups map[int]*int) {

        var fnDecode = func(e, w int) []int {
                row := e / w
                col := e % w
                return []int{row,col}
        }

        var rowPeers = stonesByRow[row]
        var colPeers = stonesByCol[col]

        for _, p := range rowPeers {
                if groups[p] != nil && *(groups[p]) == groupName {
                        continue
                }

                groups[p] = intp(groupName)
                decoded := fnDecode(p, maxCol)
                dfs(decoded[0], decoded[1], maxCol, groupName, stonesByRow, stonesByCol, groups)
        }

        for _, p := range colPeers {
                if groups[p] != nil && *(groups[p]) == groupName {
                        continue
                }

                groups[p] = intp(groupName)
                decoded := fnDecode(p, maxCol)
                dfs(decoded[0], decoded[1], maxCol, groupName, stonesByRow, stonesByCol, groups)
        }

}

func intp(x int) *int {
        return &x
}

func Max(a, b int) int {
        if a > b {
                return a
        }
        return b
}