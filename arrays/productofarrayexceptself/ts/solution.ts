var nums = [1,2,3,4];
var r = productExceptSelf(nums);
console.log(r);

function productExceptSelf(nums: number[]): number[] {
    var result = new Array<number>(nums.length);

    result[0] = 1;
    result[nums.length - 1] = 1;

    var product = 1;
    // Prefixes
    for(let i = 0; i < nums.length - 1; i++) {
        product *= nums[i];
        result[i + 1] = product;
    }

    product = 1;

    for(let i = nums.length - 1; i > 0; i--) {
        product *= nums[i];
        result[i - 1] *= product;
    }

    return result;
};