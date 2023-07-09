using System;
using System.Collections.Generic;

namespace ProjectC.Algorithms
{
    public static class Merge
    {
        public static void Sort<T>(T[] arr, Sorting.Order order) where T : IComparable<T>
        {
            MergeSort(arr, 0, arr.Length - 1, order);
        }

        private static void MergeSort<T>(T[] arr, int l, int r, Sorting.Order order) where T : IComparable<T>
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;

                MergeSort(arr, l, m, order);
                MergeSort(arr, m + 1, r, order);

                MergeArray(arr, l, m, r, order);
            }
        }

        private static void MergeArray<T>(T[] arr, int l, int m, int r, Sorting.Order order) where T : IComparable<T>
        {
            int n1 = m - l + 1;
            int n2 = r - m;

            T[] L = new T[n1];
            T[] R = new T[n2];

            for (int i = 0; i < n1; i++)
                L[i] = arr[l + i];
            for (int j = 0; j < n2; j++)
                R[j] = arr[m + 1 + j];

            int k = l;
            int i1 = 0;
            int j1 = 0;

            while (i1 < n1 && j1 < n2)
            {
                if ((order == Sorting.Order.Ascending && L[i1].CompareTo(R[j1]) <= 0) || (order == Sorting.Order.Descending && L[i1].CompareTo(R[j1]) >= 0))
                {
                    arr[k] = L[i1];
                    i1++;
                }
                else
                {
                    arr[k] = R[j1];
                    j1++;
                }
                k++;
            }

            while (i1 < n1)
            {
                arr[k] = L[i1];
                i1++;
                k++;
            }

            while (j1 < n2)
            {
                arr[k] = R[j1];
                j1++;
                k++;
            }
        }

        public static void Sort<T>(T[] arr, Sorting.Order order, IComparer<T> comparer)
        {
            MergeSort(arr, 0, arr.Length - 1, order, comparer);
        }

        private static void MergeSort<T>(T[] arr, int l, int r, Sorting.Order order, IComparer<T> comparer)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;

                MergeSort(arr, l, m, order, comparer);
                MergeSort(arr, m + 1, r, order, comparer);

                MergeArray(arr, l, m, r, order, comparer);
            }
        }

        private static void MergeArray<T>(T[] arr, int l, int m, int r, Sorting.Order order, IComparer<T> comparer)
        {
            int n1 = m - l + 1;
            int n2 = r - m;

            T[] L = new T[n1];
            T[] R = new T[n2];

            for (int i = 0; i < n1; i++)
                L[i] = arr[l + i];
            for (int j = 0; j < n2; j++)
                R[j] = arr[m + 1 + j];

            int k = l;
            int i1 = 0;
            int j1 = 0;

            while (i1 < n1 && j1 < n2)
            {
                if ((order == Sorting.Order.Ascending && comparer.Compare(L[i1], R[j1]) <= 0) || (order == Sorting.Order.Descending && comparer.Compare(L[i1], R[j1]) >= 0))
                {
                    arr[k] = L[i1];
                    i1++;
                }
                else
                {
                    arr[k] = R[j1];
                    j1++;
                }
                k++;
            }

            while (i1 < n1)
            {
                arr[k] = L[i1];
                i1++;
                k++;
            }

            while (j1 < n2)
            {
                arr[k] = R[j1];
                j1++;
                k++;
            }
        }

        public static void Sort<T>(T[] arr, Sorting.Order order, Comparison<T> comparison)
        {
            MergeSort(arr, 0, arr.Length - 1, order, comparison);
        }

        private static void MergeSort<T>(T[] arr, int l, int r, Sorting.Order order, Comparison<T> comparison)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;

                MergeSort(arr, l, m, order, comparison);
                MergeSort(arr, m + 1, r, order, comparison);

                MergeArray(arr, l, m, r, order, comparison);
            }
        }

        private static void MergeArray<T>(T[] arr, int l, int m, int r, Sorting.Order order, Comparison<T> comparison)
        {
            int n1 = m - l + 1;
            int n2 = r - m;

            T[] L = new T[n1];
            T[] R = new T[n2];

            for (int i = 0; i < n1; i++)
                L[i] = arr[l + i];
            for (int j = 0; j < n2; j++)
                R[j] = arr[m + 1 + j];

            int k = l;
            int i1 = 0;
            int j1 = 0;

            while (i1 < n1 && j1 < n2)
            {
                if ((order == Sorting.Order.Ascending && comparison(L[i1], R[j1]) <= 0) || (order == Sorting.Order.Descending && comparison(L[i1], R[j1]) >= 0))
                {
                    arr[k] = L[i1];
                    i1++;
                }
                else
                {
                    arr[k] = R[j1];
                    j1++;
                }
                k++;
            }

            while (i1 < n1)
            {
                arr[k] = L[i1];
                i1++;
                k++;
            }

            while (j1 < n2)
            {
                arr[k] = R[j1];
                j1++;
                k++;
            }
        }
    }
}

