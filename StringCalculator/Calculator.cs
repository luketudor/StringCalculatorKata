using System;
using System.Linq;
using System.Net.Sockets;

namespace StringCalculator
{
    public class Calculator
    {
        public Calculator()
        {
        }


        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }
            var splitString = input.Split(',', '\n');
            return splitString.Sum(int.Parse);
        }
    }
}