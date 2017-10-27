using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A03InsertionSort;
using A06QuickSortOptimized;

namespace A07MergeSort
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            // Mergesort is a divide and conquer algorithm that was invented by John von Neumann in 1945.
            // In sorting n objects, merge sort has an average and worst-case performance of O(n log n).
            // Unlike some (efficient) implementations of quicksort, merge sort is a stable sort.
            Stopwatch watch = new Stopwatch();
            var numbers = Quickest.GenerateNumbers(100000);
            Quickest.Shuffle(numbers);

            for (int i = 0; i < 5; i++)
            {
                watch.Start();
                List<int> sorted = MergeSortAlgorithm(numbers, false, false);
                watch.Stop();
                Console.WriteLine("Measured time: " + watch.Elapsed.TotalMilliseconds + " ms.");
                watch.Reset();
            }

            //Console.WriteLine();

            //for (int i = 0; i < 5; i++)
            //{
            //    watch.Start();
            //    List<int> sorted = MergeSortAlgorithm(numbers, false, true);
            //    watch.Stop();
            //    Console.WriteLine("Measured time: " + watch.Elapsed.TotalMilliseconds + " ms.");
            //    watch.Reset();
            //}

            Console.WriteLine();

            for (int i = 0; i < 5; i++)
            {
                watch.Start();
                List<int> sorted = MergeSortAlgorithm(numbers, true, false);
                watch.Stop();
                Console.WriteLine("Measured time: " + watch.Elapsed.TotalMilliseconds + " ms.");
                watch.Reset();
            }

            //Console.WriteLine();

            //for (int i = 0; i < 5; i++)
            //{
            //    watch.Start();
            //    List<int> sorted = MergeSortAlgorithm(numbers, true, true);
            //    watch.Stop();
            //    Console.WriteLine("Measured time: " + watch.Elapsed.TotalMilliseconds + " ms.");
            //    watch.Reset();
            //}
        }

        public static List<int> MergeSortAlgorithm(List<int> numbers, bool isOptimized = false, bool isAsync = false)
        {
            if (numbers.Count <= 1)
            {
                return numbers;
            }

            if (isOptimized && numbers.Count <= 40)
            {
                return InsertionMethods.InsertMethod(numbers);
            }

            int middleIndex = numbers.Count / 2;
            var left = numbers.Take(middleIndex).ToList();
            var right = numbers.Skip(middleIndex).ToList();

            if (isAsync)
            {
                Task leftTask = Task.Run(() => MergeSortAlgorithm(left, isOptimized, isAsync));
                Task rightTask = Task.Run(() => MergeSortAlgorithm(right, isOptimized, isAsync));
                //Task.WaitAll(leftTask, rightTask);
            }
            else
            {
                left = MergeSortAlgorithm(left, isOptimized, isAsync);
                right = MergeSortAlgorithm(right, isOptimized, isAsync);
            }

            return Merge(left, right);
        }

        public static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex] <= right[rightIndex])
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            while (leftIndex < left.Count)
            {
                result.Add(left[leftIndex]);
                leftIndex++;
            }

            while (rightIndex < right.Count)
            {
                result.Add(right[rightIndex]);
                rightIndex++;
            }

            return result;
        }
    }
}
