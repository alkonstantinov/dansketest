using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace dansketest.webapi.bs.Sort
{
    public class BubbleSorter : BaseSorter, ISorter
    {
        public BubbleSorter(IConfiguration config) : base(config)
        {

        }
        public BubbleSorter(string delimiters) : base(delimiters)
        {

        }
        

        public int[] Sort(string input)
        {
            var arr = GetNumbers(input);


            for (int i = 0; i < arr.Length - 1; i++)
                for (int j = 0; j < arr.Length - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        // swap temp and arr[i]
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }

            return arr;
        }
    }
}
