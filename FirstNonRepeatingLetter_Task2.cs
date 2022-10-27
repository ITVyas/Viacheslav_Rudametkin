using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Linq;

namespace HW_7_tasks
{
    public class TaskTwoTest
    {

        private string first_non_repeating_letter(string str)
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


        [Test]
        public void Test1()
        {
            string str = "sTreSSed";
            Assert.IsTrue(string.Equals(first_non_repeating_letter(str), "T"));
        }

        [Test]
        public void Test2()
        {
            string str = "aBcAbC";
            Assert.IsTrue(string.Equals(first_non_repeating_letter(str), ""));
        }


        [Test]
        public void Test3()
        {
            string str = "";
            Assert.IsTrue(string.Equals(first_non_repeating_letter(str), ""));
        }
        

    }
}