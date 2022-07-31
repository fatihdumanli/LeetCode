var nums: number[] = [2,3,-2,4,5,-5];
var result = maxProduct(nums);
console.log(result);

function maxProduct(nums: number[]): number {
    let result: number = nums[0];

    let curMin = nums[0];
    let curMax = nums[0];

    for(let i = 1; i < nums.length; i++) {
        let tmp = curMax;
        let n = nums[i];
        curMax = Math.max(curMax * n, curMin * n, n);
        curMin = Math.min(tmp * n, curMin * n, n);

        result = Math.max(result, curMax);
    }

    return result;
};