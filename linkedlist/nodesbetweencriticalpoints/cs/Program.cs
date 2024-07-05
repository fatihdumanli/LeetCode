using System.Text.Json;

namespace cs;

public class ListNode
{
    public int val { get; set; }
    public ListNode next { get; set; }

    public ListNode(int val)
    {
        this.val = val;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var head = new ListNode(5);
        head.next = new ListNode(3);
        head.next.next = new ListNode(1);
        head.next.next.next = new ListNode(2);
        head.next.next.next.next = new ListNode(5);
        head.next.next.next.next.next = new ListNode(1);
        head.next.next.next.next.next.next = new ListNode(2);

        var r = NodesBetweenCriticalPoints(head);

        Console.WriteLine(JsonSerializer.Serialize(r));
    }

    // https://leetcode.com/problems/find-the-minimum-and-maximum-number-of-nodes-between-critical-points
    static int[] NodesBetweenCriticalPoints(ListNode head)
    {
        var prevValue = head.val;
        var ptr = head.next;
        int i = 1;
        var minDistance = Int32.MaxValue;
        var maxDistance = -1;
        var firstCriticalPointIdx = -1;
        var lastCriticalPointIdx = -1;

        while (ptr.next != null)
        {
            var nextValue = ptr.next.val;

            if (IsLocalMaxima(prevValue, nextValue, ptr.val))
            {
                if (firstCriticalPointIdx == -1) 
                    firstCriticalPointIdx = i;

                if (lastCriticalPointIdx != -1)
                    minDistance = Math.Min(minDistance, i - lastCriticalPointIdx);

                lastCriticalPointIdx = i;
            }

            if (IsLocalMinima(prevValue, nextValue, ptr.val))
            {
                if (firstCriticalPointIdx == -1) 
                    firstCriticalPointIdx = i;

                if (lastCriticalPointIdx != -1)
                    minDistance = Math.Min(minDistance, i - lastCriticalPointIdx);

                lastCriticalPointIdx = i;
            }

            if (lastCriticalPointIdx == -1 || firstCriticalPointIdx == -1)
                maxDistance = -1;
            else if (firstCriticalPointIdx == lastCriticalPointIdx)
                maxDistance = -1;
            else
                maxDistance = lastCriticalPointIdx - firstCriticalPointIdx;

            prevValue = ptr.val;
            ptr = ptr.next;
            i++;
        }

        return new int[2] {minDistance == Int32.MaxValue ? -1 : minDistance, maxDistance};
    }

    static bool IsLocalMaxima(int prevValue, int nextValue, int currentValue)
    {
        return currentValue > prevValue && currentValue > nextValue;
    }

    static bool IsLocalMinima(int prevValue, int nextValue, int currentValue)
    {
        return currentValue < prevValue && currentValue < nextValue;
    }
}
