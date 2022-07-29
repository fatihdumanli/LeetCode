let strs: string[] = ['eat', 'tea', 'tan', 'ate', 'nat', 'bat'];

var r = groupAnagrams(strs);
console.log(r);

function groupAnagrams(strs: string[]): string[][] {
    let result: string[][] = [];
    var hashmap = new Map<string, string[]>();

    for(let i = 0; i < strs.length; i++) {
        var hash = hashWord(strs[i]);

        if(hashmap.has(hash)) {
            hashmap.get(hash).push(strs[i]);
        } else {
            hashmap.set(hash, [strs[i]]);
        }
    }

    hashmap.forEach((anagrams, freq) => {
        result.push(anagrams);
    });

    return result;
};

function hashWord(str: string): string {
    let hash: string = "";
    let freq = new Array<number>(26);
    for(let i = 0; i < 26; i++) {
        freq[i] = 0;
    }

    for(let i = 0; i < str.length; i++) {
        var ascii = str[i].charCodeAt(0);
        freq[ascii - 97]++;
    }

    for(let i = 0; i < 26; i++) {
        hash += freq[i];
        hash += "-";
    }

    return hash;
}

