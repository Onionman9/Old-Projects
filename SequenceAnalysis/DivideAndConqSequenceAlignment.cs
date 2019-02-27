/*
 * Author: Gage Glenn
 * 
 * Purpose: Using the text as a referance this algorithm generates a sequence alignment matrix using the
 * divide and conquer method. it includes data reporting for the initial DNA sequences, the basic method use for complexity
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

namespace sequenceAlignment
{
    class Program
    {

        static void Main(string[] args)
        {
            //Generate new sequences, set to false to use default book example, set to true to use customized values.
            if (true)
            {
                int sampleXlength = 8; // first sequence size
                int sampleYlength = 8; // Second sequence size

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
            }

            // Generate the matrix containing all the paths
            int[,] pathMatrix = new int[sampleSequenceX.Length, sampleSequenceY.Length];

            basicMethodCounter = 0;

            for (int i = 0; i < sampleSequenceX.Length; i++)
            {
                for (int j = 0; j < sampleSequenceY.Length; j++)
                {
                    pathMatrix[i, j] = optimal(i,j);
                }
            }

            for (int j = 0; j < sampleSequenceY.Length; j++)
            {
                for (int i = 0; i < sampleSequenceX.Length; i++)
                {
                    Console.Write(cleanPrint("" + pathMatrix[i, j]) + " ");
                }
                Console.WriteLine();
            }

            // Report basic method usage
            Console.WriteLine("Basic Method Count: " + basicMethodCounter);
            Console.ReadKey();

        }

        // Basic Method Counter and rnd number generator
        static int basicMethodCounter = 0;
        static Random rnd = new Random();

        // Sequences from figure 3.19 in the text

        static char[] sampleSequenceX = new char[]{ 'T', 'A', 'A', 'G', 'G', 'T', 'C', 'A', '-' };
        static char[] sampleSequenceY = new char[]{ 'A', 'A', 'C', 'A', 'G', 'T', 'T', 'A', 'C', 'C', '-'};        

        static int m = sampleSequenceX.Length - 1;
        static int n = sampleSequenceY.Length - 1;

        // Divide and Conquer optimal path
        static int optimal(int i, int j)
        {
            basicMethodCounter++; // the optimal path method is the basic method of our algorithm
            if (i == m)
                return 2 * (n - j);
            else if (j == n)
                return 2 * (m - i);
            else
            {
                int penalty = 0;
                if (sampleSequenceX[i] == sampleSequenceY[j])
                    penalty = 0;
                else
                    penalty = 1;

                return Math.Min(Math.Min(optimal(i + 1, j + 1) + penalty, optimal(i + 1, j) + 2), optimal(i, j + 1) + 2);

            }
        }

        // basic string formatting control for small examples
        static string cleanPrint(string s)
        {
            if (s.Length == 4)
            {
                return s;
            } else if (s.Length == 3)
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
