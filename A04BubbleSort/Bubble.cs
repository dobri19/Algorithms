using System;

namespace A04BubbleSort
{
    public class Bubble
    {
        public static void Main(string[] args)
        {
            // 1. The algorithm, is a comparison sort. Although the algorithm is simple, 
            // it is too slow and impractical for most problems even when compared to insertion sort.
            // 2. Worst-case and average complexity are both О(n2).
            // When the list is already sorted (best-case), the complexity of bubble sort is only O(n).
            
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    for (int j = 0 ; j < n - 1; j++)
            //    {
            //        if (arr[j] > arr[j + 1])
            //        {
            //            int temp = arr[j + 1];
            //            arr[j + 1] = arr[j];
            //            arr[j] = temp;
            //        }
            //    }
            //}

            // Standart Variant
            int[] arr = { 5, 1, 7, 6, 2, 9, 1, 7, 3, 9 };
            bool notSorted = true;
            while (notSorted)
            {
                notSorted = false;
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                        notSorted = true;
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
