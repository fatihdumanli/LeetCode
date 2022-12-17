//var tokens = new string[] { "2", "1", "+", "3", "*" };
//var tokens = new string[] { "4", "13", "5", "/", "+" };
//var tokens = new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" };
//var tokens = new string[] { "3", "11", "5", "+", "-" };
//var tokens = new string[] { "4", "-2", "/", "2", "-3", "-", "-" };
var tokens = new string[] { "4", "13", "5", "/", "+" };
Console.WriteLine(EvalRPN(tokens));


//https://leetcode.com/problems/evaluate-reverse-polish-notation/discuss/2922775/C-Solution-with-only-1-if-block-oror-Beats-100
int EvalRPN(string[] tokens)
{
    Stack<int> stack = new Stack<int>();

    Dictionary<string, Func<int, int, int>> map = new()
    {
        { "+", (a, b) => a + b },
        { "-", (a, b) => a - b },
        { "*", (a, b) => a * b },
        { "/", (a, b) => a / b }
    };


    foreach (var token in tokens)
    {
        if (int.TryParse(token, out int val))
            stack.Push(val);
        else
        {
            var num2 = stack.Pop();
            var num1 = stack.Pop();
            stack.Push((map[token](num1, num2)));
        }
    }

    return stack.Pop();
}