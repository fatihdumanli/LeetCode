package mylist

type List struct {
	size  *int
	items []int
}

func New() List {
	return List{
		size:  getAddressHelper(0),
		items: make([]int, 4, 4),
	}
}

func (l List) Add(x int) {
	if *l.size >= len(l.items) {
		resize(l.items)
	}

	s := *l.size
	_ = s

	l.items[*l.size] = x
	*l.size++
}

func (l List) Remove(x int) {
}

func (l List) IndexOf(x int) {
}

func (l List) Contains(x int) bool {
	return false
}

//TODO finish up
func resize(slice []int) {
	newSlice := make([]int, len(slice)*2, len(slice)*2)

	for i, n := range slice {
		newSlice[i] = n
	}
	slice = newSlice
}

func getAddressHelper(x int) *int {
	return &x
}
