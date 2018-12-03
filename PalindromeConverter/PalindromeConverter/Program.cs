using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "waterrfetawx";
            Debug.Assert(CanMakePalindrome(input, 2));

            input = "racecafr";
            Debug.Assert(CanMakePalindrome(input, 2));

            input = "rascdecafr";
            Debug.Assert(!CanMakePalindrome(input, 2));
        }

        public static bool CanMakePalindrome(string input, int k)
        {
            if (k == 0)
            {
                return IsPalindrome(input);
            }
            else
            {
                int mid = input.Length / 2;

                char[] front = input.Take(mid).ToArray();
                char[] back = input.Skip(mid).Take(input.Length - mid).ToArray();

                List<char> characters = front.Except(back).Union(back.Except(front)).ToList();
                List<int> indicies = new List<int>();
                foreach (var item in characters)
                {
                    int index = -1;
                    do
                    {
                        index = input.IndexOf(item, index + 1);
                        if (index != -1)
                        {
                            indicies.Add(index);
                        }

                    } while (index != -1);               
                }
                for (int i = 1; i <= k; i++)
                {
                    List<List<int>> list = GetCombinations(indicies, i);
                    foreach (List<int> l in list)
                    {
                        string str = input;
                        int p = 0;
                        foreach (var index in l.OrderBy(x => x))
                        {
                            str = str.Remove(index - p++, 1);
                        }
                        if (IsPalindrome(str))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool IsPalindrome(string input)
        {
            Tuple<Stack<int>, Stack<int>> stacks = new Tuple<Stack<int>, Stack<int>>(new Stack<int>(), new Stack<int>());
            int i = 0;
            int j = input.Length - 1;
            while (i < j)
            {
                stacks.Item1.Push(input[i]);
                stacks.Item2.Push(input[j]);

                i++;
                j--;
            }
            while (stacks.Item1.Count() > 0 && stacks.Item2.Count() > 0)
            {
                if (stacks.Item1.Pop() != stacks.Item2.Pop())
                {
                    return false;
                }
            }
            return true;
        }

        public static List<List<int>> GetCombinations(List<int> input, int k)
        {
            List<List<int>> result = new List<List<int>>();
            if (k == 1)
            {
                foreach (var item in input)
                {
                    result.Add(new List<int>() { item });
                }
            }
            else
            {
                foreach (var item in input)
                {
                    List<List<int>> newResult = new List<List<int>>(result);
                    foreach (var list in result)
                    {
                        List<int> newList = new List<int>(list)
                        {
                            item
                        };

                        if (!newResult.Contains(newList))
                        {
                            newResult.Add(newList);
                        }
                    }
                    newResult.Add(new List<int>() { item });
                    result = new List<List<int>>(newResult);
                }
            }


            return result.Where(x => x.Count() == k).ToList();
        }
    }
}
