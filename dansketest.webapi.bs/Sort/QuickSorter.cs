using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace dansketest.webapi.bs.Sort
{
    public class QuickSorter : BaseSorter, ISorter
    {
        public QuickSorter(IConfiguration config) : base(config)
        {

        }

        public QuickSorter(string delimiters) : base(delimiters)
        {

        }

        public int[] Sort(string input)
        {
            var arr = GetNumbers(input);

            DoSort(0, arr.Length - 1, arr);



            return arr;
        }


        private void DoSort(int low, int high, int[] arr)
        {
            int pivot = 0;
            int left = 0;
            int right = 0;

            left = low;
            right = high;
            pivot = arr[low];

            while (low < high)
            {
                while ((arr[high] >= pivot) && (low < high))
                {
                    high--;
                }

                if (low != high)
                {
                    arr[low] = arr[high];
                    low++;
                }

                while ((arr[low] <= pivot) && (low < high))
                {
                    low++;
                }

                if (low != high)
                {
                    arr[high] = arr[low];
                    high--;
                }
            }

            arr[low] = pivot;
            pivot = low;
            low = left;
            high = right;

            if (low < pivot)
            {
                DoSort(low, pivot - 1, arr);
            }

            if (high > pivot)
            {
                DoSort(pivot + 1, high, arr);
            }
        }
    }
}
