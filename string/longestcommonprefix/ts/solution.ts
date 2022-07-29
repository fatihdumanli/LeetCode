let strs: string[] = ['flow', 'flower', 'flight'];
var result = longestCommonPrefix(strs);
console.log(result);

function longestCommonPrefix(strs: string[]): string {
    let min = strs[0].length;
    let prefix: string = "";

    // optimization
    if (min == 0) {
        return prefix;
    }

    // Find shortest string
    strs.forEach((val, i) => {
        // optimization
        if(val.length == 0) {
            return prefix;
        }
        min = Math.min(min, val.length);
    });

    for(let i = 0; i < min; i++) {

        let compareWith = strs[0][i];

        for(let j = 0; j < strs.length; j++)
        {
            if(strs[j][i] !== compareWith) {
                return prefix;
            }
        }

        prefix += compareWith;
    }

    return prefix;
};