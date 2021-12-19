using System;
using System.Collections.Generic;
using System.Diagnostics;
using HashMap;
using HashSet;
using List;
using Queue;
using Stack;
using StringBuilder;

namespace DesignTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();

            var queue = new MyQueue();
            queue.Enqueue(1);
            var t = queue.Dequeue();
            //t = queue.Dequeue();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            var r = queue.Dequeue();
            r = queue.Dequeue();
            r = queue.Dequeue();
            //r = queue.Dequeue();
            queue.Enqueue(9);
            r = queue.Dequeue();
            r = queue.Dequeue();
          

            var stack = new MyStack();
            stack.Push(1);   
            stack.Push(2);   
            stack.Push(3);   
            stack.Push(4);


            var isEmpty = stack.IsEmpty();
            var popped = stack.Pop();
            var poppped2 = stack.Pop();
            stack.Push(13);
            var popped3 = stack.Pop();
            stack.Pop();
            stack.Pop();
            stack.Pop();
            stack.Pop();

            var contains = false;
            var list = new MyList(2);
            list.Add(2);
            list.Add(4);
            contains = list.Contains(4);
            contains = list.Contains(2);
            list.Add(5);
            list.Add(9); 
            contains = list.Contains(4);
            list.Remove(4);
            contains = list.Contains(4);
            contains = list.Contains(2);
            list.Add(6);
            list.Add(12);

            var hashset = new MyHashSet();
            
            hashset.Add(1);
            hashset.Add(2);
            hashset.Add(2);
            hashset.Remove(2);
            contains = hashset.Contains(2);

            var hashmap = new MyHashMap();
            hashmap.Put(1, 2);
            hashmap.Remove(1);
            
            hashmap.Put(1, 2);
            hashmap.Put(1, 3);
            
            hashmap.Put(2, 9);

            var result = hashmap.Get(2);
            var result2 = hashmap.Get(9);

            var words = new[] { "foo", "bar", "all", "key" };
            BuildSentence(words);
        }


        static void BuildSentence(string[] words)
        {
            string sentence = "";
            var chars = sentence.ToCharArray();

            foreach (var word in words)
            {
                var temp = word.ToCharArray();
                sentence += word;
                var temp2 = sentence.ToCharArray();
                // 3 + 6  + 9  + 12 + 15
                // x + 2x + 3x + 4x + 5x
                // x(1 + 2 + 3 + 4 + 5)
                // x * (n * (n-1)) / 2
                // x * n^2
                // O(xn^2)
            }

            var stringBuilder = new MyStringBuilder();

            foreach (var word in words)
                stringBuilder.Append(word);

            var result = stringBuilder.ToString();
        }
    }
}
