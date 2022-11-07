using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Linq;

namespace HW_7_tasks
{
    class TaskSixTest
    {
        private int[] Split(int number)
        {
            int digitsAmount = number.ToString().Length;
            int[] digs = new int[digitsAmount];

            for (int i = 0; i < digitsAmount; i++)
            {
                int currentDisAmount = number.ToString().Length;
                int remainingPart = number % (int)(Math.Pow(10, currentDisAmount - 1));
                int digit = (number - remainingPart) / (int)(Math.Pow(10, currentDisAmount - 1));
                digs[i] = digit;
                number = remainingPart;
                if (currentDisAmount - 1 > number.ToString().Length)
                    i += currentDisAmount - number.ToString().Length - 1;
            }

            return digs;
        }


        public void PartialSort(int[] array, int startIndex, int endIndex)
        {
            int[] sortedList = new int[(endIndex - startIndex) + 1];

            for (int i = startIndex; i <= endIndex; i++)
            {
                sortedList[i - startIndex] = array[i];
            }
            List<int> newList = new List<int>(sortedList);
            newList.Sort();
            sortedList = newList.ToArray();

            for (int i = 0; i < sortedList.Length; i++)
                array[i + startIndex] = sortedList[i];
        }

        private int Merge(int[] array)
        {
            int x = 0;

            for (int i = 0; i < array.Length; i++)
                x += array[i] * (int)(Math.Pow(10, array.Length - 1 - i));

            return x;
        }
        private int NextBigger(int number) // Task 6
        {
            int[] digits = Split(number);
            if (digits.Length == 1)
                return -1;
            int pos = -1;
            for (int i = digits.Length - 2; i >= 0; i--)
            {
                pos = i;
                if (digits[i] < digits[i + 1])
                    break;
                if (i == 0)
                    return -1;
            }

            int min = digits[pos + 1];
            int minPos = pos + 1;
            for (int i = pos + 2; i < digits.Length; i++)
                if (min > digits[i] && digits[i] > digits[pos])
                {
                    minPos = i;
                    min = digits[i];
                }

            digits[minPos] = digits[pos];
            digits[pos] = min;

            PartialSort(digits, pos + 1, digits.Length - 1);
            return Merge(digits);
        }


        [Test]
        public void Test1()
        {
            int x = 43713210;
            Assert.IsTrue(NextBigger(x) == 43720113);
        }

        [Test]
        public void Test2()
        {
            int x = 9;
            Assert.IsTrue(NextBigger(x) == -1);
        }

        [Test]
        public void Test3()
        {
            int x = 2017;
            Assert.IsTrue(NextBigger(x) == 2071);
        }
    }
}
