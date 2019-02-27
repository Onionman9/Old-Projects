/*
 * Author: Gage Glenn
 * 
 * Purpose: Using the text as a referance this algorithm generates a sequence alignment matrix using the
 * divide and conquer method rewritten using dynamic programming. it includes data reporting for the initial DNA sequences, the basic method use for complexity
 * analysis and the matrix with the penalties listed. It also includes addtional quality of life methods that exist purely for
 * the experiment.
 * 
 * Because this is analyzing the complexity of genereate the matrix, a traceback method is not included
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sequenceAlignmentDynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            // Text book example
            getMinPen(sampleSequenceX, sampleSequenceY,true);
            Console.WriteLine("Basic Method Call count: " + basicMethodCounter);

            if (true)
            {
                Console.WriteLine("Custom Example: ");
                int sampleXlength = 15; // first sequence size
                int sampleYlength = 15; // Second sequence size

                sampleSequenceX = new char[sampleXlength];
                sampleSequenceY = new char[sampleYlength];

                m = sampleSequenceX.Length - 1;
                n = sampleSequenceY.Length - 1;

                // Generate randomized DNA
                for (int i = 0; i < sampleSequenceX.Length; i++)
                {
                    sampleSequenceX[i] = randomGene();
                    Console.Write(sampleSequenceX[i] + " ");
                }
                Console.WriteLine();
                for (int i = 0; i < sampleSequenceY.Length; i++)
                {
                    sampleSequenceY[i] = randomGene();
                    Console.Write(sampleSequenceY[i] + " ");
                }
                Console.WriteLine();
                Console.WriteLine("Matrix: ");
                getMinPen(sampleSequenceX, sampleSequenceY, true);

                Console.WriteLine("Basic Method Call count: " + basicMethodCounter);
                
            }
            Console.ReadKey();

        }

        // Basic Method Counter and rnd number generator
        static int basicMethodCounter = 0;
        static Random rnd = new Random();

        // Sequences from figure 3.19 in the text

        static char[] sampleSequenceX = new char[] { 'T', 'A', 'A', 'G', 'G', 'T', 'C', 'A', '-' };
        static char[] sampleSequenceY = new char[] { 'A', 'A', 'C', 'A', 'G', 'T', 'T', 'A', 'C', 'C', '-' };

        static int m = sampleSequenceX.Length;
        static int n = sampleSequenceY.Length;

        //Function for getting minimum penalty
        public static void getMinPen(char[] seqX, char[] seqY, bool flagDisplay)
        {
            basicMethodCounter = 0; // reset basic method counter
            // Optimal Path Matrix
            int[,] optMatrix = new int[n + m, n + m];

            for (int i = 0; i < n + m ; i++)            {
                for (int j = 0; j < n + m; j++)
                    optMatrix[i, j] = 0;
            }

            m = seqX.Length - 1;
            n = seqY.Length - 1;

            // calcuting the minimum penalty  
            for (int i = m; i >= 0; i--)
            {
                for (int j = n; j >= 0; j--)
                {
                    basicMethodCounter++; // the optimal path method is the basic method of our algorithm
                    if (i == m)
                        optMatrix[i,j] = 2 * (n - j);
                    else if (j == n)
                        optMatrix[i, j] = 2 * (m - i);
                    else
                    {
                        int penalty = 0;
                        if (seqX[i] == seqY[j])
                            penalty = 0;
                        else
                            penalty = 1;

                        optMatrix[i, j] = Math.Min(Math.Min(optMatrix[i + 1, j + 1] + penalty,
                                        optMatrix[i + 1, j] + 2),
                                        optMatrix[i, j + 1] + 2);

                    }
                }
            }
            // Generate Solution

            if (flagDisplay)
            {
                for (int j = 0; j < sampleSequenceY.Length; j++)
                {
                    for (int i = 0; i < sampleSequenceX.Length; i++)
                    {
                        Console.Write(cleanPrint("" + optMatrix[i, j]) + " ");
                    }
                    Console.WriteLine();
                }
            }

        }

        // basic string formatting control for small examples
        static string cleanPrint(string s)
        {
            if (s.Length == 4)
            {
                return s;
            }
            else if (s.Length == 3)
            {
                return s + " ";
            }
            else if (s.Length == 2)
            {
                return s + " " + " ";
            }
            else
            {
                return s + " " + " " + " ";
            }

        }
        // generate random gene value
        static char randomGene()
        {
            int x = rnd.Next(0, 5);

            switch (x)
            {
                case 0:
                    return 'A';
                case 1:
                    return 'C';
                case 2:
                    return 'G';
                case 3:
                    return 'T';
                case 4:
                    return '-';
                default:
                    return '-';
            }

        }
    }
}
