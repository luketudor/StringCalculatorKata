using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StringCalculator
{
    [TestFixture]
    public class StringCalculatorShould
    {
        [Test]
        public void ReturnEmptyString()
        {
            var stringCalculator = new Calculator();
            var actual = stringCalculator.Add("");
            const int expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnSingleInputAsOutput()
        {
            var stringCalculator = new Calculator();
            var actual = stringCalculator.Add("1");
            const int expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnTwoInputSum()
        {
            var stringCalculator = new Calculator();
            var actual = stringCalculator.Add("1,2");
            const int expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnMoreThanTwoInputSum()
        {
            var stringCalculator = new Calculator();
            var actual = stringCalculator.Add("1,2,1,1,1,1,1,1,1");
            const int expected = 10;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnSumForMultipleSeparatorInput()
        {
            var stringCalculator = new Calculator();
            var actual = stringCalculator.Add("1\n2,1,1,1,1,1,1,1");
            const int expected = 10;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnSumForMultipleSeparatorInput1()
        {
            var stringCalculator = new Calculator();
            var actual = stringCalculator.Add("//;\n2;1");
            const int expected = 3;

            Assert.AreEqual(expected, actual);
        }
    }
}
