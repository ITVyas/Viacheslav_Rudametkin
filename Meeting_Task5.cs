using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Linq;

namespace HW_7_tasks
{
    class TaskFiveTest
    {

        private string Meeting(string partyList) 
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

            return result.ToUpper() ;
        }


        [Test]
        public void Test1()
        {
            string list = "";
            Assert.IsTrue(string.Equals(Meeting(list), ""));
        }

        [Test]
        public void Test2()
        {
            string list = "Fred:Corwill;Wilfred:Corwill;Barney:Tornbull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
            Assert.IsTrue(string.Equals(Meeting(list), "(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)"));
        }
    }
}
