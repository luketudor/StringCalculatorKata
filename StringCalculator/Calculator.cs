using System;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string[] numbers)
        {
            if (numbers.Length == 1 && string.IsNullOrEmpty(numbers[0])) return 0;

            var sum = 0;
            var negatives = "";
            foreach (var stringValue in numbers)
            {
                var number = int.Parse(stringValue);
                if (number < 0)
                {
                    negatives += number + ", ";
                }
                sum += number;
            }

            if (string.IsNullOrEmpty(negatives)) return sum;

            negatives = negatives.TrimEnd(',', ' ');
            throw new ArgumentException("negatives not allowed: " + negatives);
        }

        public string[] Split(string input)
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