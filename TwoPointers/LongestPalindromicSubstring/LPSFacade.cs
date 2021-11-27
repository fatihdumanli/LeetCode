using LongestPalindromicSubstring.BruteForce;

namespace LongestPalindromicSubstring
{
    public class LPSFacade
    {
        private ILPSService _bruteForce = new LPSBruteForce();
        private ILPSService _optimized = new LPSOptimized();
        
        public string LPSBruteForce(string s)
        {
            return _bruteForce.GetLPS(s);
        }

        public string LPSOptimized(string s)
        {
            return _optimized.GetLPS(s);
        }
    }
}