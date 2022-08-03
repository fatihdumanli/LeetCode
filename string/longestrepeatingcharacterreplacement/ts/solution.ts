var s = "AABABBA";
var k = 1;
var r = characterReplacement(s, k);
console.log(r);

function characterReplacement(s: string, k: number): number {
    let left = 0;
    let right = 0;
    let freq: number[] = [0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0];
    var maxLength = 1;
    freq[s[right].charCodeAt(0) - "A".charCodeAt(0)]++;

    while(right <= s.length - 1) {
        var length = right - left + 1;
        var max = findMax(freq);

        if(length - max <= k) {
            // Expand
            maxLength = Math.max(maxLength, length);
            right++;

            if(right > s.length - 1) {
                return maxLength;
            }

            freq[s[right].charCodeAt(0) - "A".charCodeAt(0)]++;
        } else {
            // Shrink
            freq[s[left].charCodeAt(0) - "A".charCodeAt(0)]--;
            left++;
        }
    }

    return maxLength;
};

function findMax(freq: number[]): number {
    var max = 0;

    for(let i = 0; i < freq.length; i++) {
        max = Math.max(max, freq[i]);
    }
    return max;
}