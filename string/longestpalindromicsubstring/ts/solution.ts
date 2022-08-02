var s = "ab";
var result = longestPalindrome(s);
console.log(result);


// a b b 
// a d d e e d d a
function longestPalindrome(s: string): string {
    var maxLength = 0;
    var LPS = s[0]

    for(let i = 0; i < s.length; i++) {
        var oddRange = expandFromMiddle(s, i, i);
        var evenRange = expandFromMiddle(s, i, i + 1);
        var oddLength = oddRange[1] - oddRange[0] + 1;
        var evenLength = evenRange[1] - evenRange[0] + 1;

        if(oddLength == 1 && evenLength == 1)
            continue;

        if(oddLength > evenLength && oddLength > maxLength) {
            maxLength = oddLength;
            LPS = s.substring(oddRange[0], oddRange[1] + 1);
        } else if(evenLength > oddLength && evenLength > maxLength) {
            maxLength = evenLength;
            LPS = s.substring(evenRange[0], evenRange[1] + 1);
        }
    }

    return LPS;
};


function expandFromMiddle(s: string, left: number, right: number): number[] {

    if(s[left] != s[right]) {
        return [0, 0];
    }

    while(s[left] == s[right] && (left >= 0 && right <= s.length - 1)) {
        left--;
        right++;

        if(s[left] != s[right] || (left < 0 || right > s.length - 1)) {
            left++;
            right--;
            return [left, right];
        }
    }

    return [0,0];
};
