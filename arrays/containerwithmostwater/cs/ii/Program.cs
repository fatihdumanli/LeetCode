namespace ii;
class Program
{
    static void Main(string[] args)
    {
        //var height = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
        var height = new int[] { 3,3,3,3,9,3,3};
        var r = MaxArea(height);
        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/container-with-most-water
    // Greedy, start with most distant two points 
    // And keep squeezing the window.
    static int MaxArea(int[] height)
    {
        var left = 0;
        var right = height.Length - 1;
        
        var maxVolume = Int32.MinValue;
        
        while(left < right)
        {
            var yLower = Math.Min(height[left], height[right]);
            var volume = (right - left) * yLower;

            maxVolume = Math.Max(volume, maxVolume);
            
            if(height[left] <= height[right])
                left++;
            else
                right--;
        }
        
        return maxVolume;
    }
}
