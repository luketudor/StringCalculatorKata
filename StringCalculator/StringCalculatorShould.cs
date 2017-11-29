using System;
using NUnit.Framework;

namespace StringCalculator
{
    [TestFixture]
    public class StringCalculatorShould
    {
        [Test]
        public void ReturnEmptyArray()
        {
            var stringCalculator = new Calculator();
            var actual = stringCalculator.Add(new string[0]);
            const int expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnEmptyString()
        {
            var stringCalculator = new Calculator();
            var actual = stringCalculator.Split("");
            var expected = new string[0];

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnMoreThanTwoInputSum()
        {
            var stringCalculator = new Calculator();
            var actual = stringCalculator.Add(new[] {"1", "2", "1", "1", "1", "1", "1", "1", "1"});
            const int expected = 10;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnSingleInputAsOutput()
        {
            var stringCalculator = new Calculator();
            var actual = stringCalculator.Add(new[] {"1"});
            const int expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnSplitByComma()
        {
            var stringCalculator = new Calculator();
            var actual = stringCalculator.Split("1,2,1,1,1,1,1,1,1");
            var expected = new[] {"1", "2", "1", "1", "1", "1", "1", "1", "1"};

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnSplitByNewLine()
        {
            var stringCalculator = new Calculator();
            var actual = stringCalculator.Split("1\n2,1,1,1,1,1,1,1");
            var expected = new[] {"1", "2", "1", "1", "1", "1", "1", "1", "1"};

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnsSplitByUserDefinedDelimiter()
        {
            var stringCalculator = new Calculator();
            var actual = stringCalculator.Split("//[***]\n1***2***3");
            var expected = new[] {"1", "2", "3"};

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnsSplitByUserDefinedMultipleDelimiter()
        {
            var stringCalculator = new Calculator();
            var actual = stringCalculator.Split("//[\n][\t]\n1\n2\t3");
            var expected = new[] {"1", "2", "3"};

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnsSplitByUserDefinedMultipleDelimiterWithMulipleChars()
        {
            var stringCalculator = new Calculator();
            var actual = stringCalculator.Split("//[*****][%%]\n1*****2%%3");
            var expected = new[] {"1", "2", "3"};

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnSumForSpecifiedDelimiter()
        {
            var stringCalculator = new Calculator();
            // TODO remove square brackets
            var actual = stringCalculator.Split("//[;]\n2;1");
            var expected = new[] {"2", "1"};

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnTwoInputSum()
        {
            var stringCalculator = new Calculator();
            var actual = stringCalculator.Add(new[] {"1", "2"});
            const int expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ThrowsExceptionForNegativeInput()
        {
            var stringCalculator = new Calculator();
            const string expected = "negatives not allowed: -1, -2";

            try
            {
                stringCalculator.Add(new[] {"-1", "1", "5", "-2"});
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
    }
}