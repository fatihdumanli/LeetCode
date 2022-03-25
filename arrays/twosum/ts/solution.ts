const hashmap: Map<number, number> = new Map<number, number>();

let nums: number[] = [2,7,11,15];

function twoSum(nums: number[], target: number): number[] {
	const hashmap: Map<number, number> = new Map<number, number>();

	for(let i = 0; i < nums.length; i++) {
		const curNum: number = nums[i];
		const diff = target - curNum;

		if(hashmap.has(diff)) {
			let x: number = hashmap.get(diff)!;
      return [i, x];
		}

    if(!hashmap.has(curNum)) {
      hashmap.set(curNum, i);
    }

	}

	return [];
}

