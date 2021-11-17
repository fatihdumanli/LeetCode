using System;

namespace ContainerWithMostWater.TwoPointers
{
    public class TwoPointers 
    {
        public int MaxArea(int[] height)
        {
            int left = 0;
            int right = height.Length - 1;
        
            int maxVolume = Int32.MinValue;
        
            //The idea is shifting the indexes toward the center
            while(left <= right)
            {
                var volume = FindVolume(height, left, right);
                maxVolume = Math.Max(maxVolume, FindVolume(height, left, right));
    
                if(height[left] < height[right])
                    left++;
                else
                    right--;
            }

            return maxVolume;           
        }
        
        int FindVolume(int[] height, int left, int right)
        {
            return (right - left) * Math.Min(height[left], height[right]);                
        }
    }
}