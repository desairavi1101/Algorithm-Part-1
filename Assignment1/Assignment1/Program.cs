using System;
using System.Collections.Generic;
using System.Linq;
namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = IOHelper.ReadFileToList("input.txt").ToArray();
            long inversions;
            int []sortedArray = SortAndCountInversions(input, out inversions);

            Console.WriteLine("Inversions: {0}",inversions);
            //foreach(int i in sortedArray)
            //{
            //    Console.Write("{0} ", i);
            //}
            Console.ReadKey();
        }

        static int[] SortAndCountInversions(int[] input, out long inversions)
        {
            if(input.Length == 1)
            {
                inversions = 0;
                return input;
            }
            int mid = input.Length / 2;
            long leftInversions, rightInversions, splitInversions;
            int[] a = input.Take(mid).ToArray();
            int[] b = input.Skip(mid).Take(input.Length - mid).ToArray();
            a = SortAndCountInversions(a,out leftInversions);
            b = SortAndCountInversions(b, out rightInversions);

            int[] mergedArray = MergeAndCountSplitInversions(a, b, out splitInversions);
            
            inversions = leftInversions + rightInversions + splitInversions;
            return mergedArray;
        }
        static int[] MergeAndCountSplitInversions(int[] a, int[] b, out long splitInversions)
        {
            int i = 0, j = 0;
            splitInversions = 0;
            List<int> mergedArray = new List<int>();
            while (i < a.Length && j < b.Length)
            {
                if (a[i] < b[j])
                {
                    mergedArray.Add(a[i++]);

                }
                else
                {
                    splitInversions += a.Length - i;
                    mergedArray.Add(b[j++]);
                }
            }
            while (i < a.Length)
            {
                mergedArray.Add(a[i++]);
            }
            while (j < b.Length)
            {
                mergedArray.Add(b[j++]);
            }
            return mergedArray.ToArray();
        }
        
    }
}
