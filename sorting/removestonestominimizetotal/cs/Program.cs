var piles = new int[] { 5, 4, 9 };
var k = 2;
var r = MinStoneSum(piles, k);
Console.WriteLine(r);

int MinStoneSum(int[] piles, int k)
{
    var sum = 0;
    var pq = new PriorityQueue<int, int>();
    foreach (var p in piles)
    {
        pq.Enqueue(p, 0 - p);
        sum += p;
    }

    for (int i = 0; i < k; i++)
    {
        var max = pq.Dequeue();
        sum -= (int)Math.Floor((decimal)max / 2);
        max -= (int)Math.Floor((decimal)max / 2);
        pq.Enqueue(max, 0 - max);
    }

    return sum;
}
