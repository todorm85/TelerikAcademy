using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace DataStructures.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;


    [TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void UnionShouldWorkCorrectlyOnValidInput()
        {
            var set1 = new HashedSet<int>();
            set1.Add(5);
            set1.Add(3);

            var set2 = new HashedSet<int>();
            set2.Add(5);
            set2.Add(4);

            var expectedResultElements = new List<int>() { 3, 4, 5 };

            set1.Union(set2);

            foreach (var value in set1)
            {
                expectedResultElements.Remove(value);
            }

            Assert.AreEqual(0, expectedResultElements.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UnionShouldThrowOnInvalidInput()
        {
            var set1 = new HashedSet<int>();
            set1.Add(5);
            set1.Add(3);

            set1.Union(null);
        }

        [TestMethod]
        public void IntersectShouldWorkCorrectlyOnValidInput()
        {
            var set1 = new HashedSet<int>();
            set1.Add(1);
            set1.Add(2);
            set1.Add(3);


            var set2 = new HashedSet<int>();
            set2.Add(2);
            set2.Add(3);
            set2.Add(4);


            var expectedResultElements = new List<int>() { 2, 3 };

            set1.Intersect(set2);

            foreach (var value in set1)
            {
                expectedResultElements.Remove(value);
            }

            Assert.AreEqual(0, expectedResultElements.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IntersectShouldThrowOnInvalidInput()
        {
            var set1 = new HashedSet<int>();
            set1.Add(5);
            set1.Add(3);

            set1.Intersect(null);
        }

        [TestMethod]
        public void EnumerationShouldEnumerateAllValues()
        {
            var set1 = new HashedSet<int>();
            var valuesToRemove = new List<int>();
            for (int i = 6; i < 18; i+=2)
            {
                set1.Add(i);
                valuesToRemove.Add(i);

            }

            foreach (var value in set1)
            {
                valuesToRemove.Remove(value);
            }

            Assert.AreEqual(0, valuesToRemove.Count);
        }

        [TestMethod]
        public void FindShouldReturnTrueIfValueExists()
        {
            var set = new HashedSet<int>();
            for (int i = 15; i < 20; i++)
            {
                set.Add(i);
            }

            var actual = set.Find(17);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void FindShouldReturnFalseIfValueDoesNotExist()
        {
            var set = new HashedSet<int>();
            for (int i = 15; i < 20; i++)
            {
                set.Add(i);
            }

            var actual = set.Find(5);

            Assert.AreEqual(false, actual);
        }

        // No need for further testing since all other methods and properties of HashedSet simply forward to HashTable and have already been tested in HashTableTests.cs. Cheers!
    }
}
