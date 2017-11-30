using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class Calculator
    {
        private readonly string[] _delimiters = {",", "\n"};

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
            var delimiters = _delimiters;
            var arrayStartIndex = Regex.Match(input, "\\d").Index;

            if (input.StartsWith("//"))
            {
                delimiters = ExtractCustomDelimiter(input.Substring(0, arrayStartIndex));
            }

            var body = input.Substring(arrayStartIndex);

            var splitString = body.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            return splitString;
        }

        private string[] ExtractCustomDelimiter(string customHeader)
        {
            if (!customHeader.StartsWith("//["))
                return new[] {_delimiters[0], _delimiters[1], customHeader.ToCharArray()[2].ToString()};

            var delimiterList = new List<string>(_delimiters);

            customHeader = customHeader.Remove(customHeader.Length - 2).Remove(0, 3);

            foreach (var delim in customHeader.Split(new[] {"]["}, StringSplitOptions.None))
                delimiterList.Add(delim);

            return delimiterList.ToArray();
        }
    }
}