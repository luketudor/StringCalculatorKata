using System;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }
           
            var numbers = SplittingTheInput(input);
            var negatives = "";
            foreach (string num in numbers)
            {
                if (int.Parse(num) < 0)
                {
                    negatives += int.Parse(num) + ", ";
                }
                
            }
            if (!string.IsNullOrEmpty(negatives))
            {
                negatives = negatives.TrimEnd(',', ' ');
                throw new Exception("negatives not allowed: " + negatives);
            }
            
            return string.IsNullOrEmpty(input) ? 0 : numbers.Sum(int.Parse);
        }

        public string[] SplittingTheInput(string input)
        {
            var delimiter = ',';
            var inputArray = input.ToCharArray();
            if (input.StartsWith("//"))
            {
                delimiter = inputArray[2];
                input = input.TrimStart('/', ';', '\n');
            }

            var splitString = input.Split(delimiter, ',', '\n');

            return splitString;
        }
    }
}