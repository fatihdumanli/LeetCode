using System;

namespace SetOfStacks
{
    class Program
    {
        static void Main(string[] args)
        {
            var setOfStacks = new SetOfStack(3);

            setOfStacks.Push(4);
            setOfStacks.Push(3);
            setOfStacks.Push(6);
            setOfStacks.Push(1);
            setOfStacks.Push(3);
            setOfStacks.Push(7);
            setOfStacks.Push(1);
            setOfStacks.Push(3);
            setOfStacks.Push(2);




            setOfStacks.PopFrom(2);
            setOfStacks.PopFrom(2);
            setOfStacks.PopFrom(2);
            setOfStacks.PopFrom(2);
            setOfStacks.PopFrom(2);
            setOfStacks.PopFrom(2);
            setOfStacks.PopFrom(2);
            setOfStacks.PopFrom(2);
            setOfStacks.PopFrom(2);
            setOfStacks.PopFrom(2);
            setOfStacks.PopFrom(2);

        }
    }
}
