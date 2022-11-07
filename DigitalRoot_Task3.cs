using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Linq;

namespace HW_7_tasks
{
    class TaskThreeTest
    {
        private int DigitSum(int number)
        {
            string numberStr = number.ToString();
            int sum = 0;
            foreach (char c in numberStr)
                sum += c - '0';
            return sum;
        }
        public int DigitalRoot(int number)
        {
            if (number < 10)
                return number;

            int digSum = DigitSum(number);

            return DigitalRoot(digSum);
        }

        [Test]

        public void Test1()
        {
            int i = 123471;
            int root = DigitalRoot(i);
            Assert.IsTrue(root == 9);
        }

        [Test]

        public void Test2()
        {
            int i = 0;
            Assert.IsTrue(DigitalRoot(i) == 0);
        }
    }
}
