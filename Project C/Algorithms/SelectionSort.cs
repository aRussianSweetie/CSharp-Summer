using System;
using System.Collections.Generic;

namespace ProjectC.Algorithms
{
    public static class Selection
    {
        public static void Sort<T>(T[] arr, Sorting.Order order) where T : IComparable<T>
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minOrMaxIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if ((order == Sorting.Order.Ascending && arr[j].CompareTo(arr[minOrMaxIndex]) < 0) || (order == Sorting.Order.Descending && arr[j].CompareTo(arr[minOrMaxIndex]) > 0))
                        minOrMaxIndex = j;
                }

                T temp = arr[minOrMaxIndex];
                arr[minOrMaxIndex] = arr[i];
                arr[i] = temp;
            }
        }

        public static void Sort<T>(T[] arr, Sorting.Order order, IComparer<T> comparer)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minOrMaxIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if ((order == Sorting.Order.Ascending && comparer.Compare(arr[j], arr[minOrMaxIndex]) < 0) || (order == Sorting.Order.Descending && comparer.Compare(arr[j], arr[minOrMaxIndex]) > 0))
                        minOrMaxIndex = j;
                }

                T temp = arr[minOrMaxIndex];
                arr[minOrMaxIndex] = arr[i];
                arr[i] = temp;
            }
        }

        public static void Sort<T>(T[] arr, Sorting.Order order, Comparison<T> comparison)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minOrMaxIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if ((order == Sorting.Order.Ascending && comparison(arr[j], arr[minOrMaxIndex]) < 0) || (order == Sorting.Order.Descending && comparison(arr[j], arr[minOrMaxIndex]) > 0))
                        minOrMaxIndex = j;
                }

                T temp = arr[minOrMaxIndex];
                arr[minOrMaxIndex] = arr[i];
                arr[i] = temp;
            }
        }
    }
}
