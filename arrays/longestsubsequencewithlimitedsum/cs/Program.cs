var nums = new int[] { 4, 5, 2, 1 };
var queries = new int[] { 3, 10, 21 };
var r = AnswerQueries(nums, queries);

//https://leetcode.com/problems/longest-subsequence-with-limited-sum/
int[] AnswerQueries(int[] nums, int[] queries)
{
    var answer = new int[queries.Length];

    Array.Sort(nums);

    for (int i = 0; i < queries.Length; i++)
    {
        var q = queries[i];
        var sum = 0;
        var c = 0;

        for (int j = 0; j < nums.Length; j++)
        {
            if (sum + nums[j] > q)
            {
                answer[i] = c;
                break;
            }
            sum += nums[j];
            c++;
        }

        answer[i] = c;
    }

    return answer;
}
