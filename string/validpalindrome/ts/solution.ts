  /*
      abba
  */

console.log(isPalindrome('A man, a plan, a canal: Panama'));

function isPalindrome(s: string): boolean {
  let left: number = 0;
  let right: number = s.length - 1;

  while(left <= right) {
    let leftChar: string = s[left];
    let rightChar: string = s[right];

    if(!isLetter(s[left])) {
      left++;
      continue;
    }
    if(!isLetter(s[right])) {
      right--;
      continue;
    }

    if(isUppercased(s[left])) {
      leftChar = String.fromCharCode(s[left].charCodeAt(0) + 32);
    }

    if(isUppercased(s[right])) {
      rightChar = String.fromCharCode(s[right].charCodeAt(0) + 32);
    }

    if(leftChar !== rightChar) {
      return false;
    }

    left++;
    right--;
  }
  return true;
}


function isLetter(c: string): boolean {
  if(c.length > 1) {
    throw new Error("only a single char can be passed in");
  }
  const ascii: number = c.charCodeAt(0);
  return (ascii >= 65 && ascii <= 90) || (ascii >= 97 && ascii <= 122) || (ascii >= 48 && ascii <= 57); 
}

function isUppercased(c: string): boolean {
  const ascii: number = c[0].charCodeAt(0);
  return ascii >= 65 && ascii <= 90;
}
