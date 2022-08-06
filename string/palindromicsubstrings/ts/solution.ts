var s = "aaa";
var r = countSubstrings(s);
console.log(r);

function countSubstrings(s: string): number {
    var counter = 0;

    for(let i = 0; i < s.length; i++) {
        var odd = expandFromMiddle(s, i, i);
        var even = expandFromMiddle(s, i, i + 1);
        counter += odd;
        counter += even;
    }

    return counter;
}

function expandFromMiddle(s: string, left: number, right: number): number {
    var counter = 0;

    while(left >= 0 && s[left] == s[right] && right < s.length) {
        counter++;
        left--;
        right++;
    }
    return counter;
}