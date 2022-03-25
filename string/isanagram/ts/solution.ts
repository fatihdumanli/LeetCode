let r: boolean = isAnagram("aacc", "ccac");
console.log(`the function returned: ${r}`);

function isAnagram(s: string, t: string): boolean {
  if(s.length != t.length) {
    return false;
  }
  const freq: Map<number, number> = new Map<number, number>();
  for(let i = 0; i < s.length; i++) {
    const ascii: number = s[i].charCodeAt(0);

    if(freq.has(ascii)) {
      const curVal: number = freq.get(ascii)!;
      freq.set(ascii, curVal + 1);
    } else {
      freq.set(ascii, 1);
    }
  }

  for(let i = 0; i < t.length; i++) {
    const ascii: number = t[i].charCodeAt(0);

    if(freq.has(ascii)) {
      const curVal: number = freq.get(ascii)!;
      freq.set(ascii, curVal - 1);
    } else {
      return false;
    }
  }

  for(let i = 97; i < 122; i++) {
    const occurences: number = freq.get(i)!;
    if(occurences > 0) {
      return false;
    }
  }

  return true;
};