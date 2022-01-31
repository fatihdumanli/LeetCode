using System;

namespace ValidParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "}}";
            var result = IsValid(s);
            Console.WriteLine("Hello World!");
        }
        
        static bool IsValid(string s) {
              
                char[] stack = new char[s.Length];
                int current = 0;
                //}}
                for(int i = 0; i < s.Length; i++)
                {
                    if(s[i] == '(' || s[i] == '[' || s[i] == '{') {
                        stack[current++] = s[i];
                        continue;
                    }

                    switch (s[i])
                    {
                        case ')':
                            if (current == 0 || stack[--current] != '(') return false;
                            break;
                        case '}':
                            if (current == 0 || stack[--current] != '{') return false;
                            break;
                        case ']':
                            if (current == 0 || stack[--current] != '[') return false;
                            break;
                    }
                }
                
                return true;
                
            }
    }
}
