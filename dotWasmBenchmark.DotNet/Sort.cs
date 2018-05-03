using System;
using System.Collections.Generic;

namespace BakkBenchmark.DotNet
{
    public class Sort
    {
        public static void QuickSort(double[] list)
        {
            QuickSort(list, 0, list.Length);
        }

        private static void QuickSort(double[] list, int left, int right)
        {
            if (list == null || list.Length <= 1)
                return;

            if (left < right)
            {
                int pivotIdx = Partition(list, left, right);
                //Console.WriteLine("MQS " + left + " " + right);
                //DumpList(list);
                QuickSort(list, left, pivotIdx - 1);
                QuickSort(list, pivotIdx, right);
            }
        }

        private static int Partition(double[] list, int left, int right)
        {
            int start = left;
            double pivot = list[start];
            left++;
            right--;

            while (true)
            {
                while (left <= right && list[left] <= pivot)
                    left++;

                while (left <= right && list[right] > pivot)
                    right--;

                if (left > right)
                {
                    list[start] = list[left - 1];
                    list[left - 1] = pivot;

                    return left;
                }


                double temp = list[left];
                list[left] = list[right];
                list[right] = temp;

            }
        }

    }
}