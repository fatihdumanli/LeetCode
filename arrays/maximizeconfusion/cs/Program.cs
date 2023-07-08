string answerKey = "";

if(args.Count() > 0 )
    answerKey = args[0];

if(string.IsNullOrEmpty(answerKey))
    answerKey = "FFTTFFTFF";

var r = MaxConsecutiveAnswers(answerKey, 1);

Console.WriteLine(r);

// https://leetcode.com/problems/maximize-the-confusion-of-an-exam/
int MaxConsecutiveAnswers(string answerKey, int k) {
    var max = 1;

    // 1. Seek longest sequence for T - with k rooms for F
    // 2. Seek longest sequence for F - with k rooms for T
    // 3. Return longest
    var tStart = 0;
    var fStart = 0;
    
    var rooms = k;
    var right = tStart;

    // 1. Seek longest sequence for T - with k rooms for F
    while(right < answerKey.Length)
    {
        if(answerKey[right] == 'F')
            rooms--;
        
        if(rooms == -1)
        {
            while(tStart < answerKey.Length && answerKey[tStart] != 'F')
                tStart++;

            tStart++;
            rooms++;
        }

        // valid window here
        max = Math.Max(max, right - tStart + 1);
        right++;
    }

    // 2. Seek longest sequence for F - with k rooms for T
    rooms = k;
    right = fStart;

    while(right < answerKey.Length)
    {
        if(answerKey[right] == 'T')
            rooms--;
        
        if(rooms == -1)
        {
            // Find next F
            while(fStart < answerKey.Length && answerKey[fStart] != 'T')
                fStart++;
            
            fStart++;
            rooms++;
        }

        // valid window here
        max = Math.Max(max, right - fStart + 1);
        right++;
    }

    return max;
}