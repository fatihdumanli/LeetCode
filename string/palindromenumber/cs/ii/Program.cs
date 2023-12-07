// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var r = IsPalindrome(111);
Console.WriteLine(r);

bool IsPalindrome(int x) {

    var list = new List<int>();
    
    if(x < 0) {
        return false;
    }
    
    if(x < 10)
        return true;

    while(x > 0) {
        list.Add(x % 10);
        x /= 10;
    }
    
    var left = 0;
    var right = list.Count - 1;
    
    if(left == right)
        return true;

    if(list[left] != list[right])
        return false;

    while(left <= right && list[left++] == list[right--])
    {
        if(list[left] != list[right])
            return false;
    }
    
    return true;
}
