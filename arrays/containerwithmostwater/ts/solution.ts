var height: number[] = [1,8,6,2,5,4,8,3,7];
var result = maxArea(height);
console.log(result);

function maxArea(height: number[]): number {
    let maxArea: number = 0;

    var left = 0;
    var right = height.length - 1;

    while(left < right) {

        maxArea = Math.max(maxArea, getArea(left, right, height[left], height[right]));

        if(height[left] <= height[right]) {
            left++;
        } else {
            right--;
        }
    }

    return maxArea;
};

function getArea(x1: number, x2: number, heightAtX1: number, heightAtx2: number) {
    return Math.min(heightAtX1, heightAtx2) * (x2 - x1);
};