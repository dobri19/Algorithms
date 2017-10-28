using System;

namespace A02SelectionSortStable
{
    public class SelectionStable
    {
        public static void Main(string[] args)
        {
            // selection sorting with insert , it is stable but Θ(n2) writes
            // time complexity of selection sort is O(n2), for best, average, and worst case scenarios
            int[] arr = new int[] { 7, 4, 1, 5, 4, 65, 2, -3, 5, 22, 6, 4, 1 };
            int min, temp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    while (min > 0 && min > i)
                    {
                        temp = arr[min - 1];
                        arr[min - 1] = arr[min];
                        arr[min] = temp;
                        min--;
                    }
                }
            }
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
        }
    }
}
