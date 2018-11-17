using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rem_ArrayProd
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> input = new List<int>() { 1, 2, 3, 4, 5 };
            List<int> expected = new List<int>() { 120, 60, 40, 30, 24 };
            List<int> actual = Operate(input);
            int i = 0;
            foreach (var item in actual)
            {
                Debug.Assert(item.Equals(expected.ElementAt(i++)));
            }

            input = new List<int>() { 3, 2, 1 };
            expected = new List<int>() { 2, 3, 6 };
            actual = Operate(input);
            i = 0;
            foreach (var item in actual)
            {
                Debug.Assert(item.Equals(expected.ElementAt(i++)));
            }
        }

        public static List<int> Operate(List<int> input)
        {

            List<int> result = new List<int>();
            
            int[] prefix = new int[input.Count];
            int[] suffix = new int[input.Count];
            int n = input.Count;
            int j = n - 1;
            int pre = 1;
            int suf = 1;
            prefix[0] = pre;
            for (int i = 1; i < input.Count; i++)
            {
                pre = pre * input[i - 1];
                prefix[i] = pre;
            }

            suffix[n - 1] = 1;
            for (int i = input.Count - 1; i > 0; i--)
            {
                suf = suf * input[i];
                suffix[i-1] = suf;
            }

            for (int i = 0; i < n; i++)
            {
                result.Add(prefix[i] * suffix[i]);
            }

            return result;
        }
    }
}
