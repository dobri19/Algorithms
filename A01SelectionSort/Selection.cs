using System;

namespace A01SelectionSort
{
    public class Selection
    {
        public static void Main(string[] args)
        {
            // selection sorting with swap , it is not stable
            // time complexity of selection sort is O(n2), for best, average, and worst case scenarios
            int[] arr = new int[] { 7, 4, 5, 4, 1, 0, 45, 3, 2, 7, 3 };
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
                    temp = arr[i];
                    arr[i] = arr[min];
                    arr[min] = temp;
                }
            }
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
        }
    }
}
