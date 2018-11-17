using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Interleaver
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> inputData = new List<int>() { 1, 2, 3, 4, 5 };
            Stack<int> input = new Stack<int>(inputData);

            List<int> expectedData = new List<int>() { 1, 5, 2, 4, 3 };
            Stack<int> expected = new Stack<int>(expectedData);

            Stack<int> output = Interleave(input);

            Debug.Assert(output.Equals(input));

            inputData = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            input = new Stack<int>(inputData);

            expectedData = new List<int>() { 1, 10, 2, 9, 3, 8, 4, 7, 5, 6 };
            expected = new Stack<int>(expectedData);

            output = Interleave(input);

            Debug.Assert(output.Equals(input));


            inputData = new List<int>() { 1, 2, 3, 4 };
            input = new Stack<int>(inputData);

            expectedData = new List<int>() { 1, 4, 2, 3 };
            expected = new Stack<int>(expectedData);

            output = Interleave(input);

            Debug.Assert(output.Equals(input));

        }

        public static Stack<int> Interleave(Stack<int> stack)
        {
            Queue<int> que = new Queue<int>();

            while (stack.Any())
            {
                que.Enqueue(stack.Pop());
            }

            int mid = que.Count / 2;
            for (int i = 0; i < mid; i++)
            {
                stack.Push(que.Dequeue());

            }

            for (int i = 0; i < mid; i++)
            {
                que.Enqueue(que.Dequeue());
                que.Enqueue(stack.Pop());
            }

            while (que.Any())
            {
                stack.Push(que.Dequeue());
            }
            return stack;
        }
    }
}
