/*
 * Author: Gage Glenn
 * Date: 2/9/2019
 * 
 * This is a quicksort algorithm with additional data methods added for algorithm analysis. It was built
 * in part from the psuedocode in the text Foundations of Algorithms 5th edition by Richard E Neapolitan - Chapter 2.
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        public static int basicOpCounter = 0;
        /*
         * Purpose: Sort elements using a traditional quicksort
         */
        public static void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Segment(arr, left, right);
                if (pivot > 1)
                {
                    QuickSort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    QuickSort(arr, pivot + 1, right);
                }
            }
        }
        /*
         * Purpose: Useing the left @param as a pivot all elements will be sorted into the array based on size in comparison to the pivot
         */
        private static int Segment(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {
                basicOpCounter++;
                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;

                    if (arr[left] == arr[right])
                    {
                        left++;
                    }
                }
                else
                {
                    return right;
                }
            }
        }
        static void Main(string[] args)
        {
            int[] baseArr;

            Random randomInt = new Random(13378); // random int

            int arraySize = 12; // array size (Note that the int represents 2^n or 2^arraySize)

            baseArr = new int[(int)Math.Pow(2, arraySize)];

            for (int i = 0; i < baseArr.Length; i++)
            {
                baseArr[i] = randomInt.Next(0, (baseArr.Length * 5)); // Generate a wide variety of values based on array size
            }
            Console.WriteLine();

            var timeQuick = new System.Diagnostics.Stopwatch();

            // Start Timing
            timeQuick.Start();
            QuickSort(baseArr, 0, baseArr.Length - 1);
            timeQuick.Stop();
            // End Timing

            // Print Data
            Console.Write("\n");
            Console.Write("QuickSort Array Size:" + baseArr.Length + "\n");
            Console.Write("Basic Method Use Count:" + basicOpCounter + "\n");
            Console.WriteLine($"Execution Time: {timeQuick.ElapsedMilliseconds} ms");
            Console.WriteLine("Element Order Check");
            // Uncomment to verify sortedness 

            //for (int i = 0; i < baseArr.Length; i++)
            //{
            //    Console.Write(baseArr[i] + " ");
            //}
            Console.Read();


        }
    }
}

