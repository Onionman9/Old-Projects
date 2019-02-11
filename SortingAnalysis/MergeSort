/*
 * Author: Gage Glenn
 * Date: 2/9/2019
 * 
 * This is a traditional mergersort algorithm with additional data methods added for algorithm analysis. It was built
 * in part from the psuedocode in the text Foundations of Algorithms 5th edition by Richard E Neapolitan - Chapter 2.
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
* Purpose: Analysis on Mergesort, obtain data on the basic method of mergesort          
*/
namespace Mergesort
{
    class Program
    {
         public static int basicOpCounter = 0;
        static void Main(string[] args)
        {
            List<int> baseList = new List<int>();
            List<int> sortedList;

            Random randomInt = new Random(1225623); // random int

            int arraySize = 12; // array size (Note that the int represents 2^n)

            arraySize = (int)Math.Pow(2, arraySize);

            for (int i = 0; i < arraySize; i++)
            {
                baseList.Add(randomInt.Next(0, arraySize * 5));                
            }
            Console.WriteLine();

            var timeMerge = new System.Diagnostics.Stopwatch();

            // Start Timing
            timeMerge.Start();
            sortedList = MergeSort(baseList);
            timeMerge.Stop();
            // End Timing

            Console.Write("\n");
            Console.Write("Mergesort List Size:" + arraySize + "\n");
            Console.Write("Basic Method Use Count:" + basicOpCounter + "\n");
            Console.WriteLine($"Execution Time: {timeMerge.ElapsedMilliseconds} ms");
            Console.Read();
        }

        /*
         * Purpose: Return sorted list using mergesort, recursively break the list down
         */
        private static List<int> MergeSort(List<int> unsorted)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int mid = unsorted.Count / 2;
            for (int i = 0; i < mid; i++)  //Dividing the unsorted list
            {
                left.Add(unsorted[i]);
            }
            for (int i = mid; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);            
            return Merge(left, right);
        }
        /*
         * Purpose: Merge 2 elements
         */
        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                basicOpCounter++; // The Basic Operation in mergesort is the comparison that takes place inside merge
                if (left.Count > 0 && right.Count > 0)
                {
                    // Compare the first 2 elements,                     
                    if (left.First() <= right.First())  
                    {
                        result.Add(left.First());
                        left.Remove(left.First());
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }

            }
            return result;
        }
    }
}
