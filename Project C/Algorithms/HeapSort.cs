using System;
using System.Collections.Generic;

namespace ProjectC.Algorithms
{
    public static class Heap
    {
        public static void Sort<T>(T[] arr, Sorting.Order order) where T : IComparable<T>
        {
            int n = arr.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(arr, n, i, order);

            for (int i = n - 1; i >= 0; i--)
            {
                T temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                Heapify(arr, i, 0, order);
            }
        }

        private static void Heapify<T>(T[] arr, int n, int i, Sorting.Order order) where T : IComparable<T>
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && ((order == Sorting.Order.Ascending && arr[l].CompareTo(arr[largest]) > 0) || (order == Sorting.Order.Descending && arr[l].CompareTo(arr[largest]) < 0)))
                largest = l;

            if (r < n && ((order == Sorting.Order.Ascending && arr[r].CompareTo(arr[largest]) > 0) || (order == Sorting.Order.Descending && arr[r].CompareTo(arr[largest]) < 0)))
                largest = r;

            if (largest != i)
            {
                T temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;

                Heapify(arr, n, largest, order);
            }
        }

        public static void Sort<T>(T[] arr, Sorting.Order order, IComparer<T> comparer)
        {
            int n = arr.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(arr, n, i, order, comparer);

            for (int i = n - 1; i >= 0; i--)
            {
                T temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                Heapify(arr, i, 0, order, comparer);
            }
        }

        private static void Heapify<T>(T[] arr, int n, int i, Sorting.Order order, IComparer<T> comparer)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && ((order == Sorting.Order.Ascending && comparer.Compare(arr[l], arr[largest]) > 0) || (order == Sorting.Order.Descending && comparer.Compare(arr[l], arr[largest]) < 0)))
                largest = l;

            if (r < n && ((order == Sorting.Order.Ascending && comparer.Compare(arr[r], arr[largest]) > 0) || (order == Sorting.Order.Descending && comparer.Compare(arr[r], arr[largest]) < 0)))
                largest = r;

            if (largest != i)
            {
                T temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;

                Heapify(arr, n, largest, order, comparer);
            }
        }

        public static void Sort<T>(T[] arr, Sorting.Order order, Comparison<T> comparison)
        {
            int n = arr.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(arr, n, i, order, comparison);

            for (int i = n - 1; i >= 0; i--)
            {
                T temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                Heapify(arr, i, 0, order, comparison);
            }
        }

        private static void Heapify<T>(T[] arr, int n, int i, Sorting.Order order, Comparison<T> comparison)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && ((order == Sorting.Order.Ascending && comparison(arr[l], arr[largest]) > 0) || (order == Sorting.Order.Descending && comparison(arr[l], arr[largest]) < 0)))
                largest = l;

            if (r < n && ((order == Sorting.Order.Ascending && comparison(arr[r],arr[largest]) > 0) || (order == Sorting.Order.Descending && comparison(arr[r], arr[largest]) < 0)))
                largest = r;

            if (largest != i)
            {
                T temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;

                Heapify(arr, n, largest, order, comparison);
            }
        }
    }
}

