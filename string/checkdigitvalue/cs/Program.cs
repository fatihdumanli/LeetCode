//https://leetcode.com/problems/check-if-number-has-equal-digit-count-and-digit-value/

var num = "1210";
var result = DigitCount(num);
Console.WriteLine(result);

// return TRUE if, for every index i, occurs num[i] times in num

/*
    | 0 | 1 | 2 | 3 |
      1   2   1   0
*/
bool DigitCount(string num)
{
    int[] asciiarr = new int[10]
    {
        48, 49, 50, 51, 52, 53, 54, 55, 56, 57
    };

    var occurences = new Dictionary<int, int>();
    for(int i = 0; i < 10; i++) 
    {
        occurences.Add(asciiarr[i], 0);
    }


    for(int i = 0; i < num.Length; i++) 
    {
        var val = num[i];
        occurences[val]++;
    }

    for(int i = 0; i < num.Length; i++) 
    {
        var key = asciiarr[i];
        var val = Convert.ToInt32(num[i].ToString());

        if(occurences[key] != val)
            return false;
    }

    return true;
}

