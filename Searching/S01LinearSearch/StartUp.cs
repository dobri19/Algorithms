using System;
using System.Collections.Generic;

namespace S01LinearSearch
{
    public class StartUp
    {
        /* 
           Worst and average performance: O(n)
           As a result, even though in theory other search algorithms may be faster than linear search 
           (for instance binary search), in practice even on medium-sized arrays (around 100 items or less) 
           it might be infeasible to use anything else. On larger arrays, it only makes sense to use other, 
           faster search methods if the data is large enough, because the initial time to prepare (sort) 
           the data is comparable to many linear searches [7]
        */
        public static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 2, 3, 6, 10, -4, 55, 3, 7 };
            Console.WriteLine(LinearSearch(list, 10));
        }

        public static int LinearSearch(List<int> list, int x)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == x)
                {
                    return x;
                }
            }

            return -1;
        }
    }
}
