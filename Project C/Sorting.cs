using System;
using System.Collections.Generic;
using ProjectC.Algorithms;

namespace ProjectC
{
    public static class Sorting
    {
        public enum Order { Ascending, Descending };
        public enum Algorithm { Insertion, Selection, Heap, Quick, Merge };

        public static void Sort<T>(T[] arr, Order order, Algorithm algorithm) where T : IComparable<T>
        {
            switch (algorithm)
            {
                case Algorithm.Insertion:
                    Insertion.Sort(arr, order);
                    break;
                case Algorithm.Selection:
                    Selection.Sort(arr, order);
                    break;
                case Algorithm.Heap:
                    Heap.Sort(arr, order);
                    break;
                case Algorithm.Quick:
                    Quick.Sort(arr, order);
                    break;
                case Algorithm.Merge:
                    Merge.Sort(arr, order);
                    break;
                default:
                    throw new ArgumentException("Invalid sorting algorithm");
            }
        }

        public static void Sort<T>(T[] arr, Order order, Algorithm algorithm, IComparer<T> comparer)
        {
            switch (algorithm)
            {
                case Algorithm.Insertion:
                    Insertion.Sort(arr, order, comparer);
                    break;
                case Algorithm.Selection:
                    Selection.Sort(arr, order, comparer);
                    break;
                case Algorithm.Heap:
                    Heap.Sort(arr, order, comparer);
                    break;
                case Algorithm.Quick:
                    Quick.Sort(arr, order, comparer);
                    break;
                case Algorithm.Merge:
                    Merge.Sort(arr, order, comparer);
                    break;
                default:
                    throw new ArgumentException("Invalid sorting algorithm");
            }
        }

        public static void Sort<T>(T[] arr, Order order, Algorithm algorithm, Comparison<T> comparison)
        {
            switch (algorithm)
            {
                case Algorithm.Insertion:
                    Insertion.Sort(arr, order, comparison);
                    break;
                case Algorithm.Selection:
                    Selection.Sort(arr,order, comparison);
                    break;
                case Algorithm.Heap:
                    Heap.Sort(arr, order, comparison);
                    break;
                case Algorithm.Quick:
                    Quick.Sort(arr, order, comparison);
                    break;
                case Algorithm.Merge:
                    Merge.Sort(arr, order, comparison);
                    break;
                default:
                    throw new ArgumentException("Invalid sorting algorithm");
            }
        }
    }
}
