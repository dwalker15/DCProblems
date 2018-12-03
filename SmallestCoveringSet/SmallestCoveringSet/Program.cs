using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestCoveringSet
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tuple<int, int>> input = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(0,5),
                new Tuple<int, int>(0,1),
                new Tuple<int, int>(3,4),
                new Tuple<int, int>(4,7),
                new Tuple<int, int>(6,9)

            };


            HashSet<int> set = SmallestCoveringSet(input);
        }

        public static HashSet<int> SmallestCoveringSet(List<Tuple<int, int>> input)
        {
            HashSet<int> resultSet = new HashSet<int>();
            if (input.Count() == 0)
            {
                return new HashSet<int>();
            }
            if (input.Count() == 1)
            {
                return new HashSet<int>() { input.First().Item1 };
            }

            Dictionary<string, Tuple<int, int>> intersections = new Dictionary<string, Tuple<int, int>>
            {
                { "0", input.ElementAt(0) }
            };
            Dictionary<string, Tuple<int, int>> newIntersections = new Dictionary<string, Tuple<int, int>>();

            int i = 1;

            foreach (Tuple<int, int> item in input.Skip(1))
            {
                newIntersections = new Dictionary<string, Tuple<int, int>>(intersections);
                bool hasIntersect = false;
                foreach (KeyValuePair<string, Tuple<int, int>> intersect in intersections)
                {
                    List<int> interval1 = new List<int>();
                    for (int j = item.Item1; j <= item.Item2; j++)
                    {
                        interval1.Add(j);
                    }

                    List<int> interval2 = new List<int>();
                    for (int k = intersect.Value.Item1; k <= intersect.Value.Item2; k++)
                    {
                        interval2.Add(k);
                    }

                    if (interval1.Intersect(interval2).Any())
                    {
                        List<int> list = interval1.Intersect(interval2).ToList();
                        newIntersections.Remove(intersect.Key);
                        newIntersections.Add(intersect.Key + i.ToString(), new Tuple<int, int>(list.First(), list.Last()));
                        hasIntersect = true;  
                    }
                }
                if (!hasIntersect)
                {
                    newIntersections.Add(i.ToString(), new Tuple<int, int>(item.Item1, item.Item2));
                }
                i++;
                intersections = new Dictionary<string, Tuple<int, int>>(newIntersections);
            }
            resultSet = new HashSet<int>(intersections.Values.Select(x => x.Item1).ToList());
            return resultSet;
        }
    }
}
