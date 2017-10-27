using System;
using System.Collections.Generic;

namespace A03InsertionSort
{
    public class Insertion
    {
        public static void Main(string[] args)
        {
            // 1.More efficient in practice than most other simple quadratic (i.e., O(n2)) algorithms
            // such as selection sort or bubble sort
            // 2.Efficient for (quite) small data sets, much like other quadratic sorting algorithms
            // 3.stable
            // 4.only requires a constant amount O(1) of additional memory space
            // 5.best case O(n2), worst case O(n2) , average case O(n2),
            // average case is also quadratic, which makes insertion sort impractical for 
            // sorting large arrays.
            // 6.insertion sort is one of the fastest algorithms for sorting very small arrays, 
            // even faster than quicksort
            // 7.In general, insertion sort will write to the array O(n2) times, whereas selection sort 
            // will write only O(n) times. For this reason selection sort may be preferable in cases 
            // where writing to memory is significantly more expensive than reading
            // 8.The size of list for which insertion sort has the advantage varies by environment 
            // and implementation, but is typically between eight and twenty elements.
            int[] arr = { 5, 1, 7, 6, 2, 9, 1, 7, 3, 9 };
            for (int i = 1; i < arr.Length; i++)
            {
                int j = i;
                while ((j > 0) && (arr[j] < arr[j - 1]))
                {
                    int temp = arr[j - 1];
                    arr[j - 1] = arr[j];
                    arr[j] = temp;
                    j--;
                }
            }
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
        }
    }
    public class InsertionMethods
    {
        public static List<int> InsertMethod(List<int> numbers)
        {
            for (int i = 1; i < numbers.Count; i++)
            {
                int j = i;
                while ((j > 0) && (numbers[j] < numbers[j - 1]))
                {
                    int temp = numbers[j - 1];
                    numbers[j - 1] = numbers[j];
                    numbers[j] = temp;
                    j--;
                }
            }

            return numbers;
        }
    }
}
