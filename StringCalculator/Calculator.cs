using System;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

namespace StringCalculator
{
    public class Calculator
    {
        public Calculator()
        {
        }


        public int Add(string input)
        {
            string[] splitString;
           var inputArray = input.ToCharArray();
            if (input.StartsWith("/"))
            {
                var delimiter = inputArray[2];
                string output = input.TrimStart('/', ';', '\n');
               splitString = output.Split(delimiter, '\n');
                return splitString.Sum(int.Parse);
            }

            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }
            splitString = input.Split(',', '\n');
            return splitString.Sum(int.Parse);
        }
    }
}