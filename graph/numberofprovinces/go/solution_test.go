package main

import "testing"

func Test_NumOfProvinces(t *testing.T) {

	data := []struct {
		isConnected [][]int
		expected    int
	}{
		{[][]int{{1, 1, 0}, {1, 1, 0}, {0, 0, 1}}, 2},
		{[][]int{{1, 0, 0}, {0, 1, 0}, {0, 0, 1}}, 3},
	}

	for _, d := range data {

		t.Run("a", func(t *testing.T) {
			actual := findCircleNum(d.isConnected)

			if actual != d.expected {
				t.Errorf("expected %d, got %d", d.expected, actual)
			}
		})
	}
}
