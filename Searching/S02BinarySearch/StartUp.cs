using System;
using System.Collections.Generic;

namespace S02BinarySearch
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            /// Average performance	O(log n)
            /// Auxiliary Space: O(1) in case of iterative implementation. In case of recursive implementation, 
            /// O(Logn) recursion call stack space.
            List<int> list = new List<int> { 1, 2, 10, 10, 10, 10, 10, 55, 367, 767 };
            //list.Sort();
            Console.WriteLine(BinarySearch(list, 10));
        }

        public static int BinarySearch(List<int> list, int element)
        {
            //return SearchRecursive(list, 0, list.Count - 1, element);
            return SearchIterativeFirstMet(list, 0, list.Count, element);
        }

        private static int SearchRecursive(List<int> list, int from, int to, int element)
        {
            if (list == null || list.Count == 0)
            {
                return -1;
            }

            if (from == to)
            {
                if (list[from] == element)
                {
                    return element;
                }

                return -1;
            }

            var mid = (from + to) / 2;

            if (list[mid] == element)
            {
                return element;
            }

            if (list[mid] > element)
            {
                return SearchRecursive(list, from, mid, element);
            }

            return SearchRecursive(list, mid + 1, to, element);
        }

        private static int SearchIterative(List<int> list, int from, int to, int element)
        {
            while (from <= to)
            {
                if (list == null || list.Count == 0)
                {
                    return -1;
                }

                if (from == to)
                {
                    if (list[from] == element)
                    {
                        return element;
                    }

                    return -1;
                }

                var mid = (from + to) / 2;

                if (list[mid] == element)
                {
                    return element;
                }

                if (list[mid] > element)
                {
                    to = mid - 1;
                }
                else
                {
                    from = mid + 1;
                }
            }

            return -1;
        }

        private static int SearchIterativeFirstMet(List<int> list, int from, int to, int element)
        {
            while (from < to)
            {
                if (list == null || list.Count == 0)
                {
                    return -1;
                }

                var mid = (from + to) / 2;

                if (list[mid] < element)
                {
                    from = mid + 1;
                }
                else
                {
                    to = mid;
                }
            }

            if (element == list[from])
            {
                return from;
            }
            else
            {
                return -1;
            }
        }
    }
}
