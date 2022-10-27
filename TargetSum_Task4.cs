using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Linq;


namespace HW_7_tasks
{
    class TaskFourTest
    {
        private int CountPairsWithTargetSum(int[] array, int targetSum) 
        {
            int amount = 0;
            for (int i = 0; i < array.Length; i++)
                for (int j = i + 1; j < array.Length; j++)
                    if (array[i] + array[j] == targetSum)
                        amount++;
            return amount;
        }

        [Test]
        public void Test1()
        {
            int[] array = new int[] { 1, 3, 6, 2, 2, 0, 4, 5 };
            Assert.IsTrue(CountPairsWithTargetSum(array, 5) == 4);
        }

        [Test]
        public void Test2()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5 };
            Assert.IsTrue(CountPairsWithTargetSum(array, 10) == 0);
        }
    }
}
