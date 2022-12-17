//var tokens = new string[] { "2", "1", "+", "3", "*" };
//var tokens = new string[] { "4", "13", "5", "/", "+" };
//var tokens = new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" };
//var tokens = new string[] { "3", "11", "5", "+", "-" };
var tokens = new string[] { "4", "-2", "/", "2", "-3", "-", "-" };
Console.WriteLine(EvalRPN(tokens));


//https://leetcode.com/problems/evaluate-reverse-polish-notation/discuss/2922775/C-Solution-with-only-1-if-block-oror-Beats-100
int EvalRPN(string[] tokens)
{
    Stack<string> stack = new Stack<string>();

    Dictionary<char, Func<int, int, int>> map = new Dictionary<char, Func<int, int, int>>();
    map.Add('+', (a, b) => a + b);
    map.Add('-', (a, b) => a - b);
    map.Add('*', (a, b) => a * b);
    map.Add('/', (a, b) =>
    {
        if (Math.Abs(a / b) < 1)
        {
            return 0;
        }
        return a / b;
    });

    for (int i = 0; i < tokens.Length; i++)
    {
        if (IsNumber(tokens[i]))
        {
            stack.Push(tokens[i]);
        }
        else
        {
            var op = tokens[i][0];

            var num2 = Convert.ToInt32(stack.Pop());
            var num1 = Convert.ToInt32(stack.Pop());

            stack.Push((map[op](num1, num2)).ToString());
        }
    }

    return Convert.ToInt32(stack.Pop());
}

bool IsNumber(string x)
{
    return Int32.TryParse(x, out int i);
}
