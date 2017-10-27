using System;
using System.Collections.Generic;
using A03InsertionSort;
using System.Threading.Tasks;
using System.Diagnostics;

namespace A06QuickSortOptimized
{
    public class Quickest
    {
        public static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            var numbers = GenerateNumbers(100000);
            Shuffle(numbers);
            // Console.WriteLine(string.Join(", ", numbers));

            // Console.WriteLine();

            // List<int> sorted = QuickSort(numbers);

            for (int i = 0; i < 5; i++)
            {
                watch.Start();
                List<int> sorted = QuickSortDobri(numbers, false, false);
                watch.Stop();
                Console.WriteLine("Measured time: " + watch.Elapsed.TotalMilliseconds + " ms.");
                watch.Reset();
            }

            Console.WriteLine();

            for (int i = 0; i < 5; i++)
            {
                watch.Start();
                List<int> sorted = QuickSortDobri(numbers, true, false);
                watch.Stop();
                Console.WriteLine("Measured time: " + watch.Elapsed.TotalMilliseconds + " ms.");
                watch.Reset();
            }

            Console.WriteLine();

            for (int i = 0; i < 5; i++)
            {
                watch.Start();
                List<int> sorted = QuickSortDobri(numbers, true, true);
                watch.Stop();
                Console.WriteLine("Measured time: " + watch.Elapsed.TotalMilliseconds + " ms.");
                watch.Reset();
            }

            Console.WriteLine();

            for (int i = 0; i < 5; i++)
            {
                watch.Start();
                List<int> sorted = QuickSort(numbers);
                watch.Stop();
                Console.WriteLine("Measured time: " + watch.Elapsed.TotalMilliseconds + " ms.");
                watch.Reset();
            }

            // my sort is twice slower
            // watch.Start();
            // List<int> sorted2 = QuickSort(numbers);
            // watch.Stop();
            // Console.WriteLine("Measured time: " + watch.Elapsed.TotalMilliseconds + " ms.");

            // Console.WriteLine(string.Join(", ", sorted));
        }

        public static List<int> QuickSortDobri(List<int> numbers, bool isOptimized = false, bool isAsync = false)
        {
            //// stable variant
            if (numbers == null || numbers.Count <= 1)
            {
                return numbers;
            }

            // call insertion sort when elements reach below 30 (about 20 % better times)
            if (isOptimized && numbers.Count <= 30)
            {
                return InsertionMethods.InsertMethod(numbers);
            }

            int pivotIndex = numbers.Count / 2;
            //int pivot = numbers[pivotIndex];

            int firstElement = numbers[0];
            int middleElement = numbers[pivotIndex];
            int lastElement = numbers[numbers.Count - 1];

            int pivot = GetAverageValue(firstElement, middleElement, lastElement);

            List<int> result = new List<int>();
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            for (int i = 0; i < pivotIndex; i++)
            {
                if (numbers[i] <= pivot)
                {
                    left.Add(numbers[i]);
                }
                else
                {
                    right.Add(numbers[i]);
                }
            }

            for (int i = pivotIndex + 1; i < numbers.Count; i++)
            {
                if (numbers[i] < pivot)
                {
                    left.Add(numbers[i]);
                }
                else
                {
                    right.Add(numbers[i]);
                }
            }

            if (isAsync)
            {
                Task leftTask = Task.Run(() => QuickSortDobri(left, isOptimized, isAsync));
                Task rightTask = Task.Run(() => QuickSortDobri(right, isOptimized, isAsync));
                //Task.WaitAll(leftTask, rightTask);
            }
            else
            {
                left = QuickSortDobri(left, isOptimized, isAsync);
                right = QuickSortDobri(right, isOptimized, isAsync);
            }

            result.AddRange(left);
            result.Add(pivot);
            result.AddRange(right);

            return result;
        }

        public static List<int> QuickSort(List<int> numbers)
        {
            if (numbers.Count <= 1)
            {
                return numbers;
            }

            int lastIndex = numbers.Count - 1;
            int pivot = numbers[lastIndex];
            int currentIndex = 0;

            while (lastIndex > currentIndex)
            {
                if (pivot < numbers[currentIndex])
                {
                    Swap(numbers, lastIndex, lastIndex - 1);
                    if (lastIndex - 1 != currentIndex)
                    {
                        Swap(numbers, currentIndex, lastIndex);
                        lastIndex--;
                    }
                }
                else
                {
                    currentIndex++;
                }
            }

            List<int> newList = new List<int>();
            List<int> left = QuickSort(numbers.GetRange(0, lastIndex));
            List<int> right = QuickSort(numbers.GetRange(lastIndex, numbers.Count - lastIndex));
            for (int i = 0; i < left.Count; i++)
            {
                newList.Add(left[i]);
            }
            for (int j = 0; j < right.Count; j++)
            {
                newList.Add(right[j]);
            }

            // QuickSort(numbers.GetRange(0, lastIndex));
            // QuickSort(numbers.GetRange(lastIndex, numbers.Count - lastIndex));

            return newList;
        }

        public static int GetAverageValue(int firstElement, int secondElement, int thirdElement)
        {
            if (firstElement.CompareTo(secondElement) > 0)
            {
                if (secondElement.CompareTo(thirdElement) > 0)
                {
                    return secondElement;
                }
                else if (firstElement.CompareTo(thirdElement) > 0)
                {
                    return thirdElement;
                }
                else
                {
                    return firstElement;
                }
            }
            else
            {
                if (firstElement.CompareTo(thirdElement) > 0)
                {
                    return firstElement;
                }
                else if (secondElement.CompareTo(thirdElement) > 0)
                {
                    return thirdElement;
                }
                else
                {
                    return secondElement;
                }
            }
        }

        public static List<int> GenerateNumbers(int maxNumber)
        {
            List<int> result = new List<int>();
            for (int i = 1; i <= maxNumber; i++)
            {
                result.Add(i);
            }

            return result;
        }

        public static void Shuffle<T>(List<T> numbers)
        {
            Random random = new Random();

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                int randomIndex = random.Next(i + 1, numbers.Count);
                Swap(numbers, i, randomIndex);
            }
        }

        public static void Swap<T>(List<T> numbers, int firstIndex, int secondIndex)
        {
            T swap = numbers[firstIndex];
            numbers[firstIndex] = numbers[secondIndex];
            numbers[secondIndex] = swap;
        }
    }
}
