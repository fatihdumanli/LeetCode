using System;
using System.Collections.Generic;

namespace SumOfTwoIntegers3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static int Add(int a, int b)
        {
            while (b != 0)
            {
                var tmp = (a & b) << 1;
                a = a ^ b;
                b = tmp;
            }

            return a;
        }
    }
}