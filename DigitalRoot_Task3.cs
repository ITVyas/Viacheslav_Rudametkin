using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Linq;

namespace HW_7_tasks
{
    class TaskThreeTest
    {
        private int DigitalRoot(int number, int sum)
        {
            if (number == 0)
                return sum;

            int digitsAmount = number.ToString().Length;
            int remainingPart = number % (int)(Math.Pow(10, digitsAmount - 1));
            int digit = (number - remainingPart) / (int)(Math.Pow(10, digitsAmount - 1));

            return DigitalRoot(remainingPart, sum + digit);
        }

        private int DigitalRoot(int number)
        {
            return DigitalRoot(number, 0);
        }

        [Test]

        public void Test1()
        {
            int i = 123471;
            Assert.IsTrue(DigitalRoot(i) == 18);
        }

        [Test]

        public void Test2()
        {
            int i = 0;
            Assert.IsTrue(DigitalRoot(i) == 0);
        }
    }
}
