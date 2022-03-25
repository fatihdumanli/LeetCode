let prices: number[] = [7,1,5,3,6,4];

console.log(maxProfit(prices));

function maxProfit(prices: number[]): number {
  let minSoFar: number = Number.MAX_SAFE_INTEGER;
  let maxProfit: number = Number.MIN_SAFE_INTEGER;


  for(let i = 0; i < prices.length; i++) {
    let v: number = prices[i];

    minSoFar = Math.min(minSoFar, v);

    const profit: number = v - minSoFar;
    maxProfit = Math.max(maxProfit, profit);
  }

  return maxProfit;
};