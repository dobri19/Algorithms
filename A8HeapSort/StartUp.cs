﻿using A06QuickSortOptimized;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace A8HeapSort
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            var numbers = Quickest.GenerateNumbers(100000);
            Quickest.Shuffle(numbers);

            for (int i = 0; i < 5; i++)
            {
                watch.Start();
                var sorted = HeapSort<int>.Sort(numbers.ToArray());
                watch.Stop();
                Console.WriteLine("Measured time: " + watch.Elapsed.TotalMilliseconds + " ms.");
                watch.Reset();
            }
        }
    }

    public class HeapSort<T> where T : IComparable
    {
        //O(nlog(n))
        public static T[] Sort(T[] array)
        {
            //heapify
            var heap = new BMinHeap<T>();
            for (int i = 0; i < array.Length; i++)
            {
                heap.Insert(array[i]);
            }

            //now extract min until empty and return them as sorted array
            var sortedArray = new T[array.Length];
            int j = 0;
            while (heap.Count > 0)
            {
                sortedArray[j] = heap.ExtractMin();
                j++;
            }

            return sortedArray;
        }
    }

    public class BMinHeap<T> where T : IComparable
    {
        private T[] heapArray;

        public int Count { get; private set; }

        /// <summary>
        /// Initialize with optional init value
        /// </summary>
        /// <param name="initial"></param>
        public BMinHeap(IEnumerable<T> initial = null)
        {
            if (initial != null)
            {
                var initArray = new T[initial.Count()];

                int i = 0;
                foreach (var item in initial.OrderBy(x => x))
                {
                    initArray[i] = item;
                    i++;
                }

                BulkInit(initArray);
                Count = initArray.Length;
            }
            else
            {
                heapArray = new T[2];
            }
        }

        /// <summary>
        /// Initialize with given input 
        /// O(n) time complexity
        /// </summary>
        /// <param name="initial"></param>
        private void BulkInit(T[] initial)
        {
            var i = (initial.Length - 1) / 2;

            while (i >= 0)
            {
                BulkInitRecursive(i, initial);
                i--;
            }

            heapArray = initial;
        }

        /// <summary>
        /// Recursively 
        /// </summary>
        /// <param name="i"></param>
        private void BulkInitRecursive(int i, T[] initial)
        {
            var left = 2 * i + 1;
            var right = 2 * i + 2;

            var min = i;
            var parent = i;

            if (left < initial.Length
                && initial[left].CompareTo(initial[parent]) < 0)
            {
                var temp = initial[left];
                initial[left] = initial[parent];
                initial[parent] = temp;
                min = left;
            }

            if (right < initial.Length
                && initial[right].CompareTo(initial[parent]) < 0)
            {
                var temp = initial[right];
                initial[right] = initial[parent];
                initial[parent] = temp;
                min = right;
            }

            //if min is child then drill down child
            if (min != parent)
            {
                BulkInitRecursive(min, initial);
            }
        }
        //o(log(n))
        public void Insert(T newItem)
        {
            if (Count == heapArray.Length)
            {
                doubleArray();
            }

            heapArray[Count] = newItem;

            for (int i = Count; i > 0; i = (i - 1) / 2)
            {
                if (heapArray[i].CompareTo(heapArray[(i - 1) / 2]) < 0)
                {
                    var temp = heapArray[(i - 1) / 2];
                    heapArray[(i - 1) / 2] = heapArray[i];
                    heapArray[i] = temp;
                }
                else
                {
                    break;
                }
            }

            Count++;
        }

        public T ExtractMin()
        {
            if (Count == 0)
            {
                throw new Exception("Empty heap");
            }
            var min = heapArray[0];

            heapArray[0] = heapArray[Count - 1];
            Count--;

            int parentIndex = 0;

            //percolate down
            while (true)
            {
                var leftIndex = 2 * parentIndex + 1;
                var rightIndex = 2 * parentIndex + 2;

                var parent = heapArray[parentIndex];

                if (leftIndex < Count && rightIndex < Count)
                {
                    var leftChild = heapArray[leftIndex];
                    var rightChild = heapArray[rightIndex];

                    var leftIsMin = false;

                    if (leftChild.CompareTo(rightChild) < 0)
                    {
                        leftIsMin = true;
                    }

                    var minChildIndex = leftIsMin ? leftIndex : rightIndex;

                    if (heapArray[minChildIndex].CompareTo(parent) < 0)
                    {
                        var temp = heapArray[parentIndex];
                        heapArray[parentIndex] = heapArray[minChildIndex];
                        heapArray[minChildIndex] = temp;

                        if (leftIsMin)
                        {
                            parentIndex = leftIndex;
                        }
                        else
                        {
                            parentIndex = rightIndex;
                        }

                    }
                    else
                    {
                        break;
                    }
                }
                else if (leftIndex < Count)
                {
                    if (heapArray[leftIndex].CompareTo(parent) < 0)
                    {
                        var temp = heapArray[parentIndex];
                        heapArray[parentIndex] = heapArray[leftIndex];
                        heapArray[leftIndex] = temp;

                        parentIndex = leftIndex;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (rightIndex < Count)
                {
                    if (heapArray[rightIndex].CompareTo(parent) < 0)
                    {
                        var temp = heapArray[parentIndex];
                        heapArray[parentIndex] = heapArray[rightIndex];
                        heapArray[rightIndex] = temp;

                        parentIndex = rightIndex;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }

            }

            if (heapArray.Length / 2 == Count && heapArray.Length > 2)
            {
                halfArray();
            }

            return min;
        }

        //o(1)
        public T PeekMin()
        {
            if (Count == 0)
            {
                throw new Exception("Empty heap");
            }

            return heapArray[0];
        }

        private void halfArray()
        {
            var smallerArray = new T[heapArray.Length / 2];

            for (int i = 0; i < Count; i++)
            {
                smallerArray[i] = heapArray[i];
            }

            heapArray = smallerArray;
        }

        private void doubleArray()
        {
            var biggerArray = new T[heapArray.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                biggerArray[i] = heapArray[i];
            }

            heapArray = biggerArray;
        }
    }
}
