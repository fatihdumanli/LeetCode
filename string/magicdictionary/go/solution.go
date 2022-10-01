package main

func main() {
}

type MagicDictionary struct {
	words []string
}

func Constructor() MagicDictionary {
	return MagicDictionary{}
}

func (this *MagicDictionary) BuildDict(dictionary []string) {
	for _, w := range dictionary {
		this.words = append(this.words, w)
	}
}

func (this *MagicDictionary) Search(searchWord string) bool {
	for _, w := range this.words {
		if this.isOneAway(w, searchWord) {
			return true
		}
	}
	return false
}

func (this *MagicDictionary) isOneAway(w1, w2 string) bool {
	if len(w1) != len(w2) {
		return false
	}

	if w1 == w2 {
		return false
	}

	var mismatch = 1

	for i := 0; i < len(w1); i++ {
		if w1[i] != w2[i] {
			mismatch--
		}

		if mismatch < 0 {
			return false
		}
	}

	return true
}
