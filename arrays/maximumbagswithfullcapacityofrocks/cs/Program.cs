
var capacity = new int[] { 91, 54, 63, 99, 24, 45, 78 };
var rocks = new int[] { 35, 32, 45, 98, 6, 1, 25 };
var r = MaximumBags(capacity, rocks, 17);
Console.WriteLine(r);

//https://leetcode.com/problems/maximum-bags-with-full-capacity-of-rocks/
int MaximumBags(int[] capacity, int[] rocks, int additionalRocks)
{
    var answer = 0;
    for (int i = 0; i < capacity.Length; i++)
        rocks[i] = capacity[i] - rocks[i];
    Array.Sort(rocks);
    for (int i = 0; i < rocks.Length && additionalRocks > 0; i++)
    {
        additionalRocks -= rocks[i];
        answer++;
    }
    return additionalRocks >= 0 ? answer : answer - 1;
}

//using heap (priority queue)
//int MaximumBags(int[] capacity, int[] rocks, int additionalRocks) 
//{
//    var answer = 0;
//    var pq = new PriorityQueue<int, int>();
//    for (int i = 0; i < capacity.Length; i++)
//    {
//        rocks[i] = capacity[i] - rocks[i];
//        if (rocks[i] == 0)
//        {
//            answer++;
//            continue;
//        }
//
//        pq.Enqueue(rocks[i], rocks[i]);
//    }
//
//    while (pq.Count > 0 && additionalRocks > 0)
//    {
//        var elm = pq.Dequeue();
//        while (elm > 0)
//        {
//            additionalRocks -= elm;
//            elm -= elm;
//        }
//
//        if (additionalRocks >= 0)
//            answer++;
//    }
//
//    return answer;
//}