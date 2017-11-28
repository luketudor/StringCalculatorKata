using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string input)
        {
            var numbers = SplittingTheInput(input);
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