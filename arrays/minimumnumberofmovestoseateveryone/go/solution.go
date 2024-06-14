package main

import "fmt"
import "sort"

func main() {
    var seats = []int{3,20,17,2,12,15,17,4,15,20}
    var students = []int{10,13,14,15,5,2,3,14,3,18}

    r := minMovesToSeat(seats, students);

    fmt.Println(r);
}


func minMovesToSeat2(seats []int, students []int) int {
    var result = 0;

    sort.Slice(seats, func(i, j int) bool {
        return seats[i] <= seats[j];
    });

    sort.Slice(students, func(i, j int) bool {
        return students[i] <= students[j];
    });


    for i := 0; i < len(seats); i++ {
        var seatIdx = seats[i];
        var studentIdx = students[i];

        var diff = Abs(seatIdx - studentIdx);
        result += diff;
    }

    return result;
}

// https://leetcode.com/problems/minimum-number-of-moves-to-seat-everyone
func minMovesToSeat(seats []int, students []int) int {

    var seatBuckets = make([]int, 101);
    var studentBuckets = make([]int, 101);

    for i := 0; i < len(seats); i++ {
        var idx = seats[i];
        seatBuckets[idx]++;
    }

    for i := 0; i < len(students); i++ {
        var idx = students[i];
        studentBuckets[idx]++;
    }

    sort.Slice(seats, func(i, j int) bool {
        return seats[i] <= seats[j];
    });

    sort.Slice(students, func(i, j int) bool {
        return students[i] <= students[j];
    });

    var result = 0;
    var studentPtr = 0;

    for i := 0; i < len(seats); i++ {

        var seatIdx = seats[i];
        var seatCount = seatBuckets[seatIdx];
        var studentCount = studentBuckets[seatIdx];

        if seatCount == studentCount {
            continue;
        }

        if studentCount > seatCount {
            continue;
        }

        for studentCount < seatCount {
            var currentStudentIdx = students[studentPtr];

            // we can pick him up
            if studentBuckets[currentStudentIdx] > seatBuckets[currentStudentIdx] {
                var diff = Abs(seatIdx - currentStudentIdx);
                studentBuckets[currentStudentIdx]--;
                studentBuckets[seatIdx]++;
                result += diff;
                studentPtr++;
                studentCount = studentBuckets[seatIdx];
            } else {
                studentPtr++;
            }
        }
    }


    return result;
}

// Return only if the student is not seated
func Abs(a int) int {
    if a >= 0 {
        return a;
    }
    return -a;
}
