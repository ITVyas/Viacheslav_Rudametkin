using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Linq;

namespace HW_7_tasks
{
    public class Tests
    {
        static class ListFilterer // Task 1
        {
            static public List<int> GetIntegersFromList(List<object> list)
            {
                list.RemoveAll(item => !(item is int));
                List<int> newList = new List<int>();
                list.ForEach(item => newList.Add(Convert.ToInt32(item)));
                return newList;
            }
        }

        private string first_non_repeating_letter(string str) // Task 2
        {
            string strCopy = str.Clone().ToString();
            while (true)
            {
                if (strCopy.Length == 0)
                    return "";

                bool isRepeat = false;
                for (int i = 1; i < strCopy.Length; i++)
                    if (strCopy[0].ToString().ToLower() == strCopy[i].ToString().ToLower())
                    {
                        strCopy = strCopy.Remove(i, 1);
                        i--;
                        isRepeat = true;
                    }

                if (isRepeat == false)
                    return strCopy[0].ToString();
                else
                    strCopy = strCopy.Remove(0, 1);
            }
        }

        private int DigitalRoot(int number, int sum)
        {
            if (number == 0)
                return sum;

            int digitsAmount = number.ToString().Length;
            int remainingPart = number % (int)(Math.Pow(10, digitsAmount - 1));
            int digit = (number - remainingPart) / (int)(Math.Pow(10, digitsAmount - 1));

            return DigitalRoot(remainingPart, sum + digit);
        }

        private int DigitalRoot(int number) // Task 3
        {
            return DigitalRoot(number, 0);
        }

        private int CountPairsWithTargetSum(int[] array, int targetSum) // Task 4
        {
            int amount = 0;
            for (int i = 0; i < array.Length; i++)
                for (int j = i+1; j < array.Length; j++)
                    if (array[i] + array[j] == targetSum)
                        amount++;
            return amount;
        }

        private string Meeting(string partyList) // Task 5
        {
            if (partyList.Trim() == "")
                return "";

            string partyListClone = partyList.Clone().ToString();
            int guestsAmount = 1 + partyList.Count<char>(i => i == ';');

            int guestsProcessed = 0;
            string[] names = new string[guestsAmount];

            while (true)
            {
                int colIndex = partyListClone.IndexOf(':');
                names[guestsProcessed] = partyListClone.Substring(0, colIndex);

                int semicolIndex = partyListClone.IndexOf(';');
                if (semicolIndex != -1)
                {
                    names[guestsProcessed] = partyListClone.Substring(colIndex + 1, semicolIndex - colIndex - 1) + ", " + names[guestsProcessed];
                    partyListClone = partyListClone.Remove(0, semicolIndex + 1);
                }
                else
                {
                    names[guestsProcessed] = partyListClone.Substring(colIndex + 1) + ", " + names[guestsProcessed];
                    break;
                }
                    
                guestsProcessed++;
            }

            Array.Sort(names);

            string result = "";
            for (int i = 0; i < guestsAmount; i++)
                result += $"({names[i]})";

            return result;
        }


        private int[] Split(int number)
        {
            int digitsAmount = number.ToString().Length;
            int[] digs = new int[digitsAmount];

            for(int i = 0; i< digitsAmount; i++)
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
                x += array[i]*(int)(Math.Pow(10, array.Length - 1 - i));

            return x;
        }
        private int NextBigger(int number) // Task 6
        {
            int[] digits = Split(number);
            int pos = -1;
            for (int i = digits.Length - 2; i >= 0; i--)
            {
                pos = i;
                if (digits[i] < digits[i + 1])
                    break;
                if (i == 0)
                    return -1;
            }

            int min = digits[pos+1];
            int minPos = pos + 1;
            for (int i = pos + 2; i < digits.Length; i++)
                if (min > digits[i] && digits[i] > digits[pos])
                {
                    minPos = i;
                    min = digits[i];
                }

            digits[minPos] = digits[pos];
            digits[pos] = min;

            PartialSort(digits, pos+1, digits.Length-1);
            return Merge(digits);
        }


        private string GetIPFrom32(uint number) // Task 7
        {
            string numberBin = "";
            while (number != 0)
            {
                if (number % 2 == 0)
                {
                    numberBin += "0";
                    number /= 2;
                }
                else
                {
                    numberBin += "1";
                    number = (number - 1) / 2;
                }
            }

            for (int i = 0; numberBin.Length != 32; i++)
                numberBin += "0";

            char[] binCodeArr = numberBin.ToCharArray();
            Array.Reverse(binCodeArr);
            numberBin = new string(binCodeArr);


            string IP = "";
            for (int i = 0; i < 4; i++)
            {
                string part = numberBin.Substring(i*8,8);
                int decodedPart = 0;
                for (int j = 0; j < 8; j++)
                    decodedPart += (part[j] == '1')? (int)Math.Pow(2, 7-j) : 0;
                IP += decodedPart.ToString();
                if (i != 3)
                    IP += ".";
            }

            return IP;
        }

        // Tests for Task 1
        [Test]
        public void Task1Test1()
        {
            List<int> list = ListFilterer.GetIntegersFromList(new List<object> {"ABC", "1", 4, 10, "", "0"});
            Assert.IsTrue(Enumerable.SequenceEqual(list, new List<int> {4, 10}));
        }


        [Test]
        public void Task1Test2()
        {
            List<int> list = ListFilterer.GetIntegersFromList(new List<object> { "ABC", "1", "4", "10", "", "0" });
            Assert.IsTrue(Enumerable.SequenceEqual(list, new List<int> {}));
        }

        // Tests for Task 2
        [Test]
        public void Task2Test1()
        {
            string str = "sTreSSed";
            Assert.IsTrue(string.Equals(first_non_repeating_letter(str), "T"));
        }

        [Test]
        public void Task2Test2()
        {
            string str = "aBcAbC";
            Assert.IsTrue(string.Equals(first_non_repeating_letter(str), ""));
        }

        [Test]
        public void Task2Test3()
        {
            string str = "";
            Assert.IsTrue(string.Equals(first_non_repeating_letter(str),""));
        }

        // Tests for Task 3

        [Test]

        public void Task3Test1()
        {
            int i = 123471;
            Assert.IsTrue(DigitalRoot(i) == 18);
        }

        [Test]

        public void Task3Test2()
        {
            int i = 0;
            Assert.IsTrue(DigitalRoot(i) == 0);
        }

        // Tests for Task 4

        [Test]
        public void Task4Test1()
        {
            int[] array = new int[] { 1,3,6,2,2,0,4,5 };
            Assert.IsTrue(CountPairsWithTargetSum(array, 5) == 4);
        }

        [Test]
        public void Task4Test2()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5 };
            Assert.IsTrue(CountPairsWithTargetSum(array, 10) == 0);
        }

        // Tests for Task 5

        [Test]
        public void Task5Test1()
        {
            string list = "";
            Assert.IsTrue(string.Equals(Meeting(list), ""));
        }

        [Test]
        public void Task5Test2()
        {
            string list = "Fred:Corwill;Wilfred:Corwill;Barney:Tornbull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
            Assert.IsTrue(string.Equals(Meeting(list), "(Corwill, Alfred)(Corwill, Fred)(Corwill, Raphael)(Corwill, Wilfred)(Tornbull, Barney)(Tornbull, Betty)(Tornbull, Bjon)"));
        }


        // Tests for Task 6

        [Test]
        public void Task6Test1()
        {
            int x = 43713210;
            Assert.IsTrue(NextBigger(x) == 43720113);
        }

        [Test]
        public void Task6Test2()
        {
            int x = 2221;
            Assert.IsTrue(NextBigger(x) == -1);
        }

        [Test]
        public void Task6Test3()
        {
            int x = 2017;
            Assert.IsTrue(NextBigger(x) == 2071);
        }

        // Tests for Task 7

        [Test]
        public void Task7Test1()
        {
            uint x = 32;
            Assert.IsTrue(string.Equals(GetIPFrom32(x), "0.0.0.32"));
        }

        [Test]
        public void Task7Test2()
        {
            uint x = 2149583361;
            Assert.IsTrue(string.Equals(GetIPFrom32(x), "128.32.10.1"));
        }

    }
}