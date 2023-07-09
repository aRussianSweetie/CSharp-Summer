using System;
using System.Collections.Generic;

namespace ProjectC.Algorithms
{
    public static class Insertion
    {
        public static void Sort<T>(T[] arr, Sorting.Order order) where T : IComparable<T>
        {
            for (int i = 1; i < arr.Length; i++)
            {
                T key = arr[i];
                int j = i - 1;

                while (j >= 0 && ((order == Sorting.Order.Ascending && arr[j].CompareTo(key) > 0) || (order == Sorting.Order.Descending && arr[j].CompareTo(key) < 0)))
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        public static void Sort<T>(T[] arr, Sorting.Order order, IComparer<T> comparer)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                T key = arr[i];
                int j = i - 1;

                while (j >= 0 && ((order == Sorting.Order.Ascending && comparer.Compare(arr[j], key) > 0) || (order == Sorting.Order.Descending && comparer.Compare(arr[j], key) < 0)))
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        public static void Sort<T>(T[] arr, Sorting.Order order, Comparison<T> comparison)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                T key = arr[i];
                int j = i - 1;

                while (j >= 0 && ((order == Sorting.Order.Ascending && comparison(arr[j], key) > 0) || (order == Sorting.Order.Descending && comparison(arr[j], key) < 0)))
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }
    }
}
