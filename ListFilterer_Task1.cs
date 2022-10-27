using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Linq;

namespace HW_7_tasks
{
    public class TaskOneTest
    {
        static class ListFilterer 
        {
            static public List<int> GetIntegersFromList(List<object> list)
            {
                list.RemoveAll(item => !(item is int));
                List<int> newList = new List<int>();
                list.ForEach(item => newList.Add(Convert.ToInt32(item)));
                return newList;
            }
        }

        [Test]
        public void Test1()
        {
            List<int> list = ListFilterer.GetIntegersFromList(new List<object> { "ABC", "1", 4, 10, "", "0" });
            Assert.IsTrue(Enumerable.SequenceEqual(list, new List<int> { 4, 10 }));
        }

        [Test]
        public void Test2()
        {
            List<int> list = ListFilterer.GetIntegersFromList(new List<object> { "ABC", "1", "4", "10", "", "0" });
            Assert.IsTrue(Enumerable.SequenceEqual(list, new List<int> { }));
        }
    }
    

   

}
