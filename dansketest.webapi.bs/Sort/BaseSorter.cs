using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dansketest.webapi.bs.Sort
{
    public class BaseSorter
    {
        protected readonly string _delimiters;

        public BaseSorter(IConfiguration config)
        {
            _delimiters = config["Delimiters"];
        }

        public BaseSorter(string delimiters)
        {
            _delimiters = delimiters;
        }

        protected int[] GetNumbers(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("Please, provide numbers");
            }

            List<int> lResult = new List<int>();
            foreach (string sn in input.Split(_delimiters.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                if (!int.TryParse(sn, out int newNumber))
                    throw new InvalidCastException($"Cannot convert {sn} to integer");
                if(newNumber<1 || newNumber>10)
                    throw new ArgumentOutOfRangeException($"{sn} must be between 1 and 10");
                lResult.Add(newNumber);
            }
            return lResult.ToArray();
        }
    }
}
