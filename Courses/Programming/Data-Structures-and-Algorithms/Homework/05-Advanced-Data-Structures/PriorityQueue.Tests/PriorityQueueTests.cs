using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MyDataStructures.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyDataStructures;

    [TestClass]
    public class PriorityQueueTests
    {
        #region GetParentIndex

        [TestMethod]
        public void GetParentIndexShouldWorkCorrectlyOnEvenNumber()
        {
            int actual = GetParentIndex(6);

            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void GetParentIndexShouldWorkCorrectlyOnOddNumber()
        {
            int actual = GetParentIndex(7);

            Assert.AreEqual(3, actual);
        }

        [TestMethod]
        public void GetParentIndexShouldReturnMinusOneForFirstElementIndex()
        {
            int actual = GetParentIndex(0);

            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetParentIndexShouldThrowOnLessThanZeroIndex()
        {
            int actual = GetParentIndex(-5);
        }

        [TestMethod]
        public void GetParentIndexShouldReturnFirstElementIndexForSecondOrThirdElementIndex()
        {
            int actual = GetParentIndex(2);

            Assert.AreEqual(0, actual);
        }

        #endregion

        #region Pop

        [TestMethod]
        public void PopShouldReturnElementsByHigherPriority1()
        {
            var pq = new PriorityQueue<int>();
            pq.Add(5);
            pq.Add(1);
            pq.Add(3);
            pq.Add(2);

            Assert.AreEqual(5, pq.Pop());
            Assert.AreEqual(3, pq.Pop());
            Assert.AreEqual(2, pq.Pop());
            Assert.AreEqual(1, pq.Pop());
        }

        [TestMethod]
        public void PopShouldReturnElementsByHigherPriority2()
        {
            var pq = new PriorityQueue<int>();
            pq.Add(15);
            pq.Add(1);
            pq.Add(31);
            pq.Add(2);
            pq.Add(17);

            Assert.AreEqual(31, pq.Pop());
            Assert.AreEqual(17, pq.Pop());
            Assert.AreEqual(15, pq.Pop());
            Assert.AreEqual(2, pq.Pop());
            Assert.AreEqual(1, pq.Pop());
        }

        [TestMethod]
        public void PopShouldReturnElementsByHigherPriority3()
        {
            var pq = new PriorityQueue<int>();
            pq.Add(1);
            pq.Add(2);
            pq.Add(3);
            pq.Add(4);
            pq.Add(5);

            Assert.AreEqual(5, pq.Pop());
            Assert.AreEqual(4, pq.Pop());
            Assert.AreEqual(3, pq.Pop());
            Assert.AreEqual(2, pq.Pop());
            Assert.AreEqual(1, pq.Pop());
        }

        [TestMethod]
        public void PopShouldReturnElementsByHigherPriority4()
        {
            var pq = new PriorityQueue<int>();
            var addedNumbers = new List<int>();

            for (int i = 0; i < 50; i++)
            {
                if (i % 3 == 0)
                {
                    int numberToAdd = (int)(i / 2);
                    pq.Add(numberToAdd);
                    addedNumbers.Add(numberToAdd);
                    continue;
                }

                if (i % 2 == 0)
                {
                    int numberToAdd = (int)(i / 2);
                    pq.Add(numberToAdd);
                    addedNumbers.Add(numberToAdd);
                    continue;
                }

                pq.Add(i);
                addedNumbers.Add(i);
            }

            addedNumbers.Sort();
            addedNumbers.Reverse();
            for (int i = 0; i < pq.Count; i++)
            {
                var poppedNumber = pq.Pop();
                Assert.AreEqual(addedNumbers[i], poppedNumber);
            }
        }

        #endregion

        #region Count

        [TestMethod]
        public void InitialQueueCountShouldBeZero()
        {
            var pq = new PriorityQueue<int>();
            Assert.AreEqual(0, pq.Count);
        }

        [TestMethod]
        public void CountShouldWorkCorrectly()
        {
            var pq = GetPriorityQueue(50);
            Assert.AreEqual(50, pq.Count);
        }

        #endregion

        #region GetChildIndex

        [TestMethod]
        public void GetChildIndexShouldReturnChildIndexOfTheBiggerOfTheTwoChildren()
        {
            var pq = new PriorityQueue<int>();
            pq.Add(5);
            pq.Add(3);
            pq.Add(4);
            pq.Add(1);
            pq.Add(2);
            pq.Add(6);

            var result = GetIndexOfBiggerChild(1, pq);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void GetChildIndexShouldReturnFirstChildIndexIfNoOtherChildExists()
        {
            var pq = new PriorityQueue<int>();
            pq.Add(5);
            pq.Add(3);
            pq.Add(4);
            pq.Add(1);
            pq.Add(2);
            pq.Add(6);

            var result = GetIndexOfBiggerChild(2, pq);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void GetChildIndexShouldReturnSecondElementIndexForFirstElementIndexIfSecondElementIsBiggerThanThirdElement()
        {
            var pq = new PriorityQueue<int>();
            pq.Add(5);
            pq.Add(8);
            pq.Add(4);

            var result = GetIndexOfBiggerChild(0, pq);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetChildIndexShouldThrowForInvalidIndex()
        {
            var pq = new PriorityQueue<int>();

            var result = GetIndexOfBiggerChild(-3, pq);
        }

        #endregion

        #region Helper methods

        private static int GetParentIndex(int value)
        {
            PriorityQueue<int> target = new PriorityQueue<int>();
            PrivateObject obj = new PrivateObject(target);
            var retVal = (int)obj.Invoke("GetParentIndex", value);
            return retVal;
        }

        private static int GetIndexOfBiggerChild(int value, PriorityQueue<int> target)
        {
            PrivateObject obj = new PrivateObject(target);
            var retVal = (int)obj.Invoke("GetIndexOfBiggerChild", value);
            return retVal;
        }

        private static PriorityQueue<int> GetPriorityQueue(int length)
        {
            var pq = new PriorityQueue<int>();
            for (int i = length - 1; i >= 0; i--)
            {
                pq.Add(i);
            }

            return pq;
        }

        #endregion
    }
}