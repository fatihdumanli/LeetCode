var temperatures = new int[] { 73, 74, 75, 71, 69, 72, 76, 73 };
DailyTemperatures(temperatures);

//https://leetcode.com/problems/daily-temperatures/
static int[] DailyTemperatures(int[] temperatures)
{
    var stack = new Stack<TemperatureNode>();

    for (int i = 0; i < temperatures.Length; i++)
    {
        if (stack.Count == 0 || temperatures[i] <= stack.Peek().Val)
            stack.Push(new TemperatureNode(temperatures[i], i));
        else
        {
            while (stack.Count > 0 && stack.Peek().Val < temperatures[i])
            {
                var popped = stack.Pop();
                temperatures[popped.Day] = i - popped.Day;
            }

            stack.Push(new TemperatureNode(temperatures[i], i));
        }
    }

    while (stack.Count > 0)
        temperatures[stack.Pop().Day] = 0;

    return temperatures;
}

public class TemperatureNode
{
    public TemperatureNode(int val, int day)
    {
        this.Val = val;
        this.Day = day;
    }

    public int Val { get; set; }
    public int Day { get; set; }
}
