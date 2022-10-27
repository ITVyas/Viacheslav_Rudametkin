using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Linq;


namespace HW_7_tasks
{

    class TaskSevenTest
    {
        private string GetIPFrom32(uint number) 
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
                string part = numberBin.Substring(i * 8, 8);
                int decodedPart = 0;
                for (int j = 0; j < 8; j++)
                    decodedPart += (part[j] == '1') ? (int)Math.Pow(2, 7 - j) : 0;
                IP += decodedPart.ToString();
                if (i != 3)
                    IP += ".";
            }

            return IP;
        }


        [Test]
        public void Test1()
        {
            uint x = 32;
            Assert.IsTrue(string.Equals(GetIPFrom32(x), "0.0.0.32"));
        }

        [Test]
        public void Test2()
        {
            uint x = 2149583361;
            Assert.IsTrue(string.Equals(GetIPFrom32(x), "128.32.10.1"));
        }
    }
}
