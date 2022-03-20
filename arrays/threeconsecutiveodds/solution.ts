let arr: number[] = [1,2,34,3,4,5,7,23,12];

function threeConsecutiveOdds(arr: number[]): boolean {
	let c = 0;
	for(let i = 0; i < arr.length; i++) {
		if(arr[i] % 2 == 1) {
			c++;
		} else {
			c = 0;
		}
		if(c >= 3) {
			return true;
		}
	}
	return false;
}
