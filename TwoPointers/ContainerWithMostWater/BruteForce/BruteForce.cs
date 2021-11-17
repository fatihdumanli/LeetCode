using System;

namespace ContainerWithMostWater.BruteForce
{
    public class BruteForce
    {
        public int MaxArea(int[] height)
        {
            int maxVolume = 0;    
    
            for(int i = 0; i < height.Length; i++)
            {
                for(int j = i; j < height.Length; j++)
                {
                    var volume = FindVolume(height, i, j);
                    maxVolume = Math.Max(maxVolume, volume);                
                }
            }
            return maxVolume;
        }
        
        int FindVolume(int[] height, int left, int right)
        {
            return (right - left) * Math.Min(height[left], height[right]);                
        }
    }
}