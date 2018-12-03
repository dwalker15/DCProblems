using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftedEquals
{
    class Program
    {
        static void Main(string[] args)
        {
            string A = "abcde";
            string B = "cdeab";
            Debug.Assert(IsShiftedEqual(A, B));

            A = "abc";
            B = "acb";
            Debug.Assert(!IsShiftedEqual(A, B));

            A = "abaabbabcabdabeabf";
            B = "bbabcabdabeabfabaa";
            Debug.Assert(IsShiftedEqual(A, B));
        }

        public static bool IsShiftedEqual(string A, string B)
        {
            List<int> indices = new List<int>();
            int index = 0;
            while (index != -1)
            {
                index = B.IndexOf(A.ElementAt(0), index + 1);
                if (index != -1)
                {
                    indices.Add(index);
                }
            }
            
            foreach (int j in indices)
            {
                int i = j;
                bool match = true;
                for (int k = 1; k < A.Count(); k++)
                {
                    if (i == A.Count() - 1)
                    {
                        i = -1;
                    }
                    if (A.ElementAt(k) != B.ElementAt(++i))
                    {
                        match = false;
                    }
                    if (!match)
                    {
                        break;
                    }
                }
                if (match)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
