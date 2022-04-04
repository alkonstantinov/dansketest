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


            for (int firstIter = 0; firstIter <= arr.Length - 2; firstIter++)
            {
                //intArray.Length - 2
                for (int secondIter = 0; secondIter <= arr.Length - 2; secondIter++)
                {
                    if (arr[secondIter] > arr[secondIter + 1])
                    {
                        int temp = arr[secondIter + 1];
                        arr[secondIter + 1] = arr[secondIter];
                        arr[secondIter] = temp;
                    }
                }
            }

            return arr;
        }
    }
}
