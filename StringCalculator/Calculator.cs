using System;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string[] numbers)
        {
            if (numbers.Length == 0) return 0;

            var sum = 0;
            var negatives = "";
            foreach (var stringValue in numbers)
            {
                var number = int.Parse(stringValue);
                if (number < 0)
                    negatives += number + ", ";
                sum += number;
            }

            if (string.IsNullOrEmpty(negatives)) return sum;

            negatives = negatives.TrimEnd(',', ' ');
            throw new ArgumentException("negatives not allowed: " + negatives);
        }

        public string[] Split(string input)
        {
            var delimiter = ",";
            if (input.StartsWith("//"))
            {
                var fullDelimiter = Regex.Match(input, "\\[.+\\]").Value;
                delimiter = fullDelimiter.Trim('[', ']');

                input = Regex.Replace(input, "//\\[.+\\]\n", delimiter);
            }

            var splitString = input.Split(new[] {delimiter, ",", "\n"}, StringSplitOptions.RemoveEmptyEntries);

            return splitString;
        }
    }
}