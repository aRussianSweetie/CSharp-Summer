using System;
using System.Collections.Generic;
using ProjectC.Algorithms;

namespace ProjectC
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 5, 2, 4, 6, 1, 3 };
            string[] arr2 = { "cherry", "apple", "blueberry" };
            char[] arr3 = { 'f', 'd', 'a', 'c', 'e', 'b' };

            Console.WriteLine("Original arrays:");
            Console.WriteLine(string.Join(", ", arr1));
            Console.WriteLine(string.Join(", ", arr2));
            Console.WriteLine(string.Join(", ", arr3));

            Sorting.Sort(arr1, Sorting.Order.Ascending, Sorting.Algorithm.Heap);
            Sorting.Sort(arr2, Sorting.Order.Descending, Sorting.Algorithm.Quick, new StringComparer());
            Sorting.Sort(arr3, Sorting.Order.Ascending, Sorting.Algorithm.Merge, (x, y) => x.CompareTo(y));

            Console.WriteLine("\nSorted arrays:");
            Console.WriteLine(string.Join(", ", arr1));
            Console.WriteLine(string.Join(", ", arr2));
            Console.WriteLine(string.Join(", ", arr3));
        }

        public class StringComparer : IComparer<string>
        {
            public int Compare(string? x, string? y)
            {
                if (x == null && y == null) return 0;
                if (x == null) return -1;
                if (y == null) return 1;
                return x.CompareTo(y);
            }
        }
    }
}
