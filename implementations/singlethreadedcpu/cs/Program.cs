using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

// https://leetcode.com/problems/single-threaded-cpu
class ProcessingTimeAndIndexBasedPriority : IComparable<ProcessingTimeAndIndexBasedPriority>
{
    public int ProcessingTime { get; set; }
    public int Index { get; set; }
    
    public ProcessingTimeAndIndexBasedPriority(int processingTime, int index)
    {
        ProcessingTime = processingTime;
        Index = index;
    }

    public int CompareTo(ProcessingTimeAndIndexBasedPriority? other)
    {
        if (ProcessingTime == other.ProcessingTime)
            return Index <= other.Index ? -1 : 1;

        if (ProcessingTime <= other.ProcessingTime)
            return -1;

        else return 1;
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        var tasks = new int[16][]
        {
            new int[] { 35, 36},
            new int[] { 11, 7},
            new int[] { 15, 47},
            new int[] { 34, 2},
            new int[] { 47, 19},
            new int[] { 16, 14},
            new int[] { 19, 8},
            new int[] { 7, 34},
            new int[] { 38, 15},
            new int[] { 16, 18},
            new int[] { 27, 22},
            new int[] { 7, 15},
            new int[] { 43, 2},
            new int[] { 10, 5},
            new int[] { 5, 4},
            new int[] { 3, 11},
        };

        var r = GetOrder(tasks);
        Console.WriteLine(JsonSerializer.Serialize(r));
    }
    static int[] GetOrder(int[][] tasks)
    {
        var result = new List<int>();

        var taskList = new int[tasks.Length][];

        for (int i = 0; i < tasks.Length; i++)
        {
            var task = tasks[i];

            taskList[i] = new int[] { task[0], task[1], i };
        }

        var ptr = 0;
        var t = 0;

        // Sort by enqueue time
        taskList = taskList.OrderBy(t => t[0]).ToArray();

        // TODO: Find available tasks with the aid of ptr, 
        // And add them to the priority queue 
        PriorityQueue<int[], ProcessingTimeAndIndexBasedPriority> queue = new();

        // set t = E of first task 
        t = taskList[0][0];

        while(result.Count < taskList.Length)
        {
            while(ptr < taskList.Length && taskList[ptr][0] <= t)
                queue.Enqueue(new int[] { taskList[ptr][1], taskList[ptr][2] }, new ProcessingTimeAndIndexBasedPriority(taskList[ptr][1], taskList[ptr++][2]));

            var item = queue.Dequeue();

            result.Add(item[1]);

            t += item[0];
            
            if(queue.Count == 0 && ptr < taskList.Length && t < taskList[ptr][0])
                t = taskList[ptr][0];
        }
        
        return result.ToArray();
    }
}




