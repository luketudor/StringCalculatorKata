using System;
using System.Collections.Generic;
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
            var delimiters = new[] {",", "\n"};
            if (input.StartsWith("//"))
            {
                var delimiterList = new List<string>(delimiters);
                var matches = Regex.Matches(input, "\\[.+?\\]"); /* [delim] */
                foreach (Match match in matches)
                    delimiterList.Add(match.Value.Trim('[', ']'));

                delimiters = delimiterList.ToArray();
                var index = Regex.Match(input, "\\d").Index;
                input = input.Substring(index);
            }

            var splitString = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            return splitString;
        }
    }
}