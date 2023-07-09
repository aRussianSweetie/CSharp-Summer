using System;
using System.Collections.Generic;

namespace ProjectC.Algorithms
{
    public static class Quick
    {
        public static void Sort<T>(T[] arr, Sorting.Order order) where T : IComparable<T>
        {
            QuickSort(arr, 0, arr.Length - 1, order);
        }

        private static void QuickSort<T>(T[] arr, int low, int high, Sorting.Order order) where T : IComparable<T>
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high, order);

                QuickSort(arr, low, pi - 1, order);
                QuickSort(arr, pi + 1, high, order);
            }
        }

        private static int Partition<T>(T[] arr, int low, int high, Sorting.Order order) where T : IComparable<T>
        {
            T pivot = arr[high];
            int i = (low - 1);

            for (int j = low; j <= high - 1; j++)
            {
                if ((order == Sorting.Order.Ascending && arr[j].CompareTo(pivot) < 0) || (order == Sorting.Order.Descending && arr[j].CompareTo(pivot) > 0))
                {
                    i++;
                    T temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            T temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return (i + 1);
        }

        public static void Sort<T>(T[] arr, Sorting.Order order, IComparer<T> comparer)
        {
            QuickSort(arr, 0, arr.Length - 1, order, comparer);
        }

        private static void QuickSort<T>(T[] arr, int low, int high,Sorting.Order order, IComparer<T> comparer)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high, order, comparer);

                QuickSort(arr, low, pi - 1, order, comparer);
                QuickSort(arr, pi + 1, high, order, comparer);
            }
        }

        private static int Partition<T>(T[] arr,int low,int high ,Sorting.Order order,IComparer<T> comparer)
        {
            T pivot=arr[high];
            int i=(low-1);

            for(int j=low;j<=high-1;j++)
            {
                if((order==Sorting.Order.Ascending&&comparer.Compare(arr[j],pivot)<0)||(order==Sorting.Order.Descending&&comparer.Compare(arr[j],pivot)>0))
                {
                    i++;
                    T temp=arr[i];
                    arr[i]=arr[j];
                    arr[j]=temp;
                }
            }

            T temp1=arr[i+1];
            arr[i+1]=arr[high];
            arr[high]=temp1;

            return(i+1);
        }

        public static void Sort<T>(T[] arr ,Sorting.Order order ,Comparison<T> comparison)
        {
            QuickSort(arr ,0 ,arr.Length - 1 ,order ,comparison);
        }

        private static void QuickSort<T>(T[]arr ,int low ,int high ,Sorting.Order order ,Comparison<T> comparison)
        {
            if(low < high)
            {
                int pi=Partition(arr ,low ,high ,order ,comparison);

                QuickSort(arr ,low ,pi-1 ,order ,comparison);
                QuickSort(arr ,pi+1 ,high ,order ,comparison);
            }
        }

        private static int Partition<T>(T[]arr,int low,int high ,Sorting.Order order ,Comparison<T> comparison)
        {
           T pivot=arr[high];
           int i=(low-1);

           for(int j=low;j<=high-1;j++)
           {
               if((order==Sorting.Order.Ascending&&comparison(arr[j],pivot)<0)||(order==Sorting.Order.Descending&&comparison(arr[j],pivot)>0))
               {
                   i++;
                   T temp=arr[i];
                   arr[i]=arr[j];
                   arr[j]=temp;
               }
           }

           T temp1=arr[i+1];
           arr[i+1]=arr[high];
           arr[high]=temp1;

           return(i+1);
        }
    }
}
